using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Services;

public interface IAuthService {
    // Task<List<Site>> GetAll();
    Task<User> Register(UserDToLogin request);
    //  void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    Task<string?> Login(UserDToLogin request);
    bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

    // Task<Site> GetById(int id);

    // Task<Site> GetByName(string name);

    // Task<Site> Create(SiteDToRegister site);

    // Task<Site> Update(int id, Site request);

    // Task<Site> Delete(int id);

    // Task<Boolean> CheckNameAvailability(SiteDToRegister request);
}
  