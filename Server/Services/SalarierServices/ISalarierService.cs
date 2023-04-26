using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Services;

public interface ISalarierService {
    Task<List<Salarier>> GetAll();

    Task<Salarier> GetById(int id);

    Task<Salarier> GetByName(string name);

    Task<Salarier> Create(SalarierDToRegister salarier);

    Task<Salarier> Delete(int id);

    Task<Salarier> Update(int id, SalarierDToRegister request);
    
    Task<Boolean> CheckEmailAvailabilityUpdateDTO(int id, SalarierDToRegister request);



    // Task<Boolean> CheckNameAvailability(SiteDToRegister request);
}
  