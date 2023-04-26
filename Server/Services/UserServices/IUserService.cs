
using BlazorApp.Shared.Models;
namespace BlazorApp.Server.Services;


public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(UserDToLogin request);
    IEnumerable<User> GetAll();
    User? GetById(int id);
  Task<User> Register(UserDToLogin request);
  Task<User?> Delete(int id);


}
