
namespace BlazorApp.Shared.Models;


public class User
{
  public int Id { get; set; }
  public string Username { get; set; } = string.Empty;
  public string PasswordHash { get; set; } = string.Empty;
  // public byte[] PasswordSalt {get; set;}

}


public class UserDToLogin
{
  public string Username { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;

}


public class AuthenticateResponse
{
  public int Id { get; set; }
  public string Username { get; set; }
  public string Token { get; set; }


  public AuthenticateResponse(User user, string token)
  {
    Id = user.Id;
    Username = user.Username;
    Token = token;
  }

}
  public class UserSession
  {
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    // public string Role { get; set; } = string.Empty;
    // public int ExpireIn { get; set; }
    // public DateTime ExpiryTimeStamp { get; set; }
  }