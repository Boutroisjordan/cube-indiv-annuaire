using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Services;

public interface IServiceService {
    Task<List<Service>> GetAll();

    Task<Service> GetById(int id);

    Task<Service> GetByName(string name);

    Task<Service> Create(ServiceDToRegister service);

    Task<Service> Update(int id, ServiceDToRegister request);

    Task<Service> Delete(int id);

  Task<Boolean> CheckNameAvailabilityUpdateDTO(int id, ServiceDToRegister request);
}
  