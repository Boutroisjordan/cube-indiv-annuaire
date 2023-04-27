using System.Security.Cryptography;
using BlazorApp.Server.Context;

using BlazorApp.Server.Helpers;

namespace BlazorApp.Server.Helpers;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
// using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public interface IJwtUtils
{
    // public RefreshToken GenerateAccessToken(User user);
    public int ValidateToken(string token);
    // public ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    // public RefreshToken GenerateRefreshToken(User user);
}

public class JwtUtils : IJwtUtils
{
    private readonly DataContext _context;
    private readonly AppSettings _appSettings;


    public JwtUtils(IOptions<AppSettings> appSettings, DataContext context)
    {
        _context = context;
        _appSettings = appSettings.Value;

    }

  // public RefreshToken GenerateAccessToken(User user)
  // {
  //     var tokenHandler = new JwtSecurityTokenHandler();
  //     var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

  //     // Crée un token d'accès valide pendant une heure

  //     var Role = _context.Roles.Include(r => r.Id).SingleOrDefault(r => r.Id == user.UserId).Name;

  //     var tokenDescriptor = new SecurityTokenDescriptor
  //     {
  //         Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()), new Claim(ClaimTypes.Role, Role) }),
  //         Expires = DateTime.UtcNow.AddHours(8),
  //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
  //     };
  //     var accessToken = tokenHandler.CreateToken(tokenDescriptor);

  //     var refreshToken = _context.RefreshToken.SingleOrDefault(r => r.UserId == user.UserId);

  //     if (refreshToken != null && refreshToken.NewToken != null && refreshToken.NewTokenExpires > DateTime.UtcNow)
  //     {
  //         if (refreshToken.AccessTokenExpires < DateTime.UtcNow)
  //         {
  //             // Mettre à jour le token d'accès expiré avec un nouveau token d'accès valide
  //             accessToken = tokenHandler.CreateToken(tokenDescriptor);
  //             refreshToken.AccessToken = tokenHandler.WriteToken(accessToken);
  //             refreshToken.AccessTokenExpires = tokenDescriptor.Expires ?? throw new Exception("Could not create access token");
  //             _context.SaveChanges();
  //         }
  //         refreshToken.AccessTokenExpires = tokenDescriptor.Expires ?? throw new Exception("Could not create access token");
  //         return refreshToken;
  //     }


  //     // Crée un token de rafraîchissement valide pendant 7 jours

  //     var refreshTokenDescriptor = new SecurityTokenDescriptor
  //     {
  //         Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()), new Claim(ClaimTypes.Role, Role) }),
  //         Expires = DateTime.UtcNow.AddDays(7),
  //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
  //     };
  //     var newRefreshToken = tokenHandler.CreateToken(refreshTokenDescriptor);

  //     // Stocke le refresh token dans la base de données pour une persistance de connexion
  //     var refreshTokenBdd = new RefreshToken
  //     {
  //         AccessToken = tokenHandler.WriteToken(accessToken),
  //         AccessTokenExpires = tokenDescriptor.Expires ?? throw new Exception("Could not create access token"),
  //         NewToken = tokenHandler.WriteToken(newRefreshToken),
  //         NewTokenExpires = refreshTokenDescriptor.Expires ?? throw new Exception("Could not create refresh token"),
  //         Created = DateTime.UtcNow,
  //         UserId = user.UserId,
  //     };
  //     _context.RefreshToken.Add(refreshTokenBdd);

  //     _context.SaveChanges();

  //     // Retourne les informations de token pour une utilisation immédiate
  //     return new RefreshToken
  //     {
  //         AccessToken = tokenHandler.WriteToken(accessToken),
  //         AccessTokenExpires = tokenDescriptor.Expires ?? throw new Exception("Could not create access token"),
  //         NewToken = refreshTokenBdd.NewToken,
  //         NewTokenExpires = refreshTokenBdd.NewTokenExpires,
  //         Created = DateTime.UtcNow,
  //     };
  // }



  public int ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        if (_appSettings.Secret is null)
        {
            throw new Exception("secret is null");
        }
        var key = string.IsNullOrEmpty(_appSettings?.Secret) ? throw new Exception("secret is null") : Encoding.ASCII.GetBytes(_appSettings.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
             
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
            var tokenBdd = _context.Users.SingleOrDefault(r => r.Id == userId);

            if(tokenBdd is null) {
                throw new Exception("error invoke authorize 1");
            }
            // return user id from JWT token if validation successful
            return tokenBdd.Id;
        }
        catch
        {
            // return null if validation fails
            throw new Exception("error invoke authorize 2");

        }
    }

  // public RefreshToken GenerateRefreshToken(User user)
  // {
  //     var tokenHandler = new JwtSecurityTokenHandler();
  //     var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

  //     // Create claims for refresh token
  //     var claims = new List<Claim>
  // {
  //     new Claim("id", user.UserId.ToString()),
  //     new Claim(ClaimTypes.Role, _context.Roles.Include(r => r.Id).SingleOrDefault(r => r.Id == user.UserId).Name)
  // };
  //     var refreshToken = _context.RefreshToken.SingleOrDefault(r => r.UserId == user.UserId);

  //     // Generate refresh access token
  //     var refreshAccessToken = new SecurityTokenDescriptor
  //     {
  //         Subject = new ClaimsIdentity(claims),
  //         Expires = DateTime.UtcNow.AddHours(8),
  //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
  //     };
  //     var newRefreshTokenAccess = tokenHandler.CreateToken(refreshAccessToken);

  //     var refreshTokenBdd = new RefreshToken
  //     {
  //         AccessToken = tokenHandler.WriteToken(newRefreshTokenAccess),
  //         AccessTokenExpires = refreshAccessToken.Expires ?? throw new Exception("Could not create refresh token"),
  //         Created = DateTime.UtcNow,
  //         NewToken = refreshToken.NewToken,
  //         NewTokenExpires = refreshToken.NewTokenExpires,
  //         UserId = user.UserId
  //     };
  //     _context.RefreshToken.Update(refreshTokenBdd);
  //     return refreshTokenBdd;
  // }



  // public ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey)
  // {
  //     var tokenHandler = new JwtSecurityTokenHandler();
  //     var key = Encoding.ASCII.GetBytes(signingKey);
  //     try
  //     {
  //         var validationParameters = new TokenValidationParameters
  //         {
  //             ValidateIssuerSigningKey = true,
  //             IssuerSigningKey = new SymmetricSecurityKey(key),
  //             ValidateIssuer = false,
  //             ValidateAudience = false,
  //             RequireExpirationTime = true,
  //             ClockSkew = TimeSpan.Zero
  //         };

  //         var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
  //         if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
  //         {
  //             return null;
  //         }

  //         return principal;
  //     }
  //     catch
  //     {
  //         return null;
  //     }
  // }

  // private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
  // {
  //     return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
  //            jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
  // }

}
