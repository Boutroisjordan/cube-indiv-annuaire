using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Services;

public interface ISiteService {
    Task<List<Site>> GetAll();

    Task<Site> GetById(int id);

    Task<Site> GetByName(string name);

    Task<Site> Create(SiteDToRegister site);

    Task<Site> Update(int id, SiteDToUpdate request);

    Task<Site> Delete(int id);

    Task<Boolean> CheckNameAvailability(SiteDToRegister request);
    Task<Boolean> CheckNameAvailabilityUpdateDTO(int id, SiteDToUpdate request);
}
  