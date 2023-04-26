using BlazorApp.Shared.Models;
using BlazorApp.Server.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Cryptography;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BlazorApp.Server.Services;

public class AuthService : IAuthService
{
  #region Fields

  private readonly DataContext _context;
  private readonly IMapper _mapper;

  private readonly IConfiguration _configuration;


  #endregion

  // #region Constructors
  public AuthService(DataContext context, IMapper mapper, IConfiguration configuration)
  {
    this._context = context;
    this._mapper = mapper;
    this._configuration = configuration;
  }
  public async Task<User> Register(UserDToLogin request)
  {
    // var dbResult = _context.Users
    // CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
    User user = new User();

    user.Username = request.Username;
    // user.PasswordHash = passwordHash;
    // user.PasswordSalt = passwordSalt;

    var result = await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();

    if (result is null)
    {
      throw new Exception("failed to create user");
    }

    return result.Entity;

  }

  // public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
  // {
  //   using (var hmac = new HMACSHA512())
  //   {
  //     passwordSalt = hmac.Key;
  //     passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
  //   }
  // }

  public async Task<string?> Login(UserDToLogin request)
  {
    var dbResult = await _context.Users.Where(x => x.Username == request.Username).FirstOrDefaultAsync();

    if (dbResult is null)
    {
      return null;
    }

    // if (!VerifyPasswordHash(request.Password, dbResult.PasswordHash, dbResult.PasswordSalt))
    // {
    //   return null;
    // }

    string token = CreateToken(dbResult);

    return token;
  }

  public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
  {
    using (var hmac = new HMACSHA512(passwordSalt))
    {
      var computehash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      return computehash.SequenceEqual(passwordHash);
    }
  }

  public string CreateToken(User user)
  {

    List<Claim> claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, user.Username)
      };
    var secretTokenKey = _configuration.GetSection("AppSettings:Token").Value;
    if (secretTokenKey != null)
    {
      var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretTokenKey));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


      var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: creds,
        issuer: _configuration.GetSection("AppSettings:Issuer").Value,
        audience: _configuration.GetSection("AppSettings:Audience").Value
      );

      var jwt = new JwtSecurityTokenHandler().WriteToken(token);

      return jwt;
    }
    else
    {
      return string.Empty;
    }
  }






}