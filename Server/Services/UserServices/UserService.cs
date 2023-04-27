namespace BlazorApp.Server.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Server.Helpers;
using BlazorApp.Shared.Models;
using BlazorApp.Server.Context;
using System.Security.Cryptography;
using BCrypt;

public class UserService : IUserService
{
  // users hardcoded for simplicity, store in a db with hashed passwords in production applications
  // private List<User> _context.Users = new List<User>
  // {
  //     new User { Id = 1, Username = "test", Password = "test" }
  // };

  private readonly AppSettings _appSettings;

  private readonly DataContext _context;


  public UserService(DataContext context, IOptions<AppSettings> appSettings)
  {
    _appSettings = appSettings.Value;
    _context = context;
  }

  public async Task<AuthenticateResponse?> Authenticate(UserDToLogin request)
  {

    // string passwordHashString = BCrypt.Net.BCrypt.HashPassword(request.Password);

    // var user = await _context.Users.Where(x => x.Username == request.Username && x.PasswordHash == passwordHashString).FirstOrDefaultAsync();
    var user = await _context.Users.Where(x => x.Username == request.Username).FirstOrDefaultAsync();
    // return null if user not found
    if (user == null)
    {

      return null;
    }

    var passwordHashString = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

    if (!passwordHashString)
    {
      Console.Write($"User name: {user.Username}  PasswordHashRecieved: {passwordHashString.ToString()} , celui en bdd: {user.PasswordHash.ToString()}");
      return null;
    }
    var token = generateJwtToken(user);

    return new AuthenticateResponse(user, token);
    

    // authentication successful so generate jwt token
  }

  public IEnumerable<User> GetAll()
  {
    return _context.Users;
  }

  public User? GetById(int id)
  {
    return _context.Users.FirstOrDefault(x => x.Id == id);
  }
  public async Task<User?> Delete(int id)
  {
    var dbResult = _context.Users.FirstOrDefault(x => x.Id == id);


    if(dbResult is null) {
      return null;
    }

    _context.Users.Remove(dbResult);
    await _context.SaveChangesAsync();

    return dbResult;
  }

  // helper methods

  private string generateJwtToken(User user)
  {
    // generate token that is valid for 7 days
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("username", user.Username) }),
      Expires = DateTime.UtcNow.AddDays(7),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }

  public async Task<User> Register(UserDToLogin request)
  {
    // var dbResult = _context.Users
    // CreatePasswordHash(request.Password, out byte[] passwordHash);
    User user = new User();
  // string passwordHashString = Convert.ToBase64String(passwordHash);
      string passwordHashString = BCrypt.Net.BCrypt.HashPassword(request.Password);

    user.Username = request.Username;
    user.PasswordHash = passwordHashString;
    // user.PasswordSalt = passwordSalt;

    var result = await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();

    if (result is null)
    {
      throw new Exception("failed to create user");
    }

    return result.Entity;

  }

    public void CreatePasswordHash(string password, out byte[] passwordHash)
  {
    using (var hmac = new HMACSHA512())
    {
      passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }
  }
}