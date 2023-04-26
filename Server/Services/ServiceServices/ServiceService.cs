using BlazorApp.Shared.Models;
using BlazorApp.Server.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BlazorApp.Server.Services;

public class ServiceService : IServiceService
{
  #region Fields

  private readonly DataContext _context;
  private readonly IMapper _mapper;

  #endregion

  // #region Constructors
  public ServiceService(DataContext context, IMapper mapper)
  {
    this._context = context;
    this._mapper = mapper;
  }

  public async Task<Service> Create(ServiceDToRegister request)
  {
    // var checkDoublons = await _context.Sites.AnyAsync();
    // var checkDoublons = await _context.Sites.Where(x => x.Name == request.Name).AnyAsync();

    // if(checkDoublons) {
    //   throw new Exception($"Site with name {request.Name} already exist");
    // }

    var mappedRequest = _mapper.Map<Service>(request);
    var result = await _context.Services.AddAsync(mappedRequest);

    if (result is null)
    {
      throw new Exception("Error create");
    }

    await _context.SaveChangesAsync();
    return result.Entity;
  }
  // public async Task<Boolean> CheckNameAvailability(SiteDToRegister request)
  // {
  //   // var checkDoublons = await _context.Sites.AnyAsync();
  //   var checkDoublons = await _context.Services.Where(x => x.Name == request.Name).AnyAsync();

  //   if (checkDoublons)
  //   {
  //     return false;
  //   }

  //   return true;
  // }

  public async Task<Service> Delete(int id)
  {
    var dbresult = await _context.Services.FindAsync(id);
    if (dbresult is null)
    {
      throw new Exception("Furnisher not found");
    }

    _context.Services.Remove(dbresult);
    await _context.SaveChangesAsync();
    return dbresult;
  }

  public Task<List<Service>> GetAll()
  {
    var dbResult = _context.Services.ToListAsync();

    if (dbResult is null)
    {
      throw new Exception("No sites found");
    }

    return dbResult;
  }

  public async Task<Service> GetById(int id)
  {
    var dbResult = await _context.Services.FindAsync(id);

    if (dbResult is null)
    {
      throw new Exception("No site found");
    }

    return dbResult;
  }

  public Task<Service> GetByName(string name)
  {
    throw new NotImplementedException();
  }

  public async Task<Service> Update(int id, ServiceDToRegister request)
  {
    var modelToUpdate = await _context.Services.Where(x => x.Id ==id).FirstOrDefaultAsync();

    if(modelToUpdate is null) {
      throw new Exception("User not found");
    }

    Service mappedRequest = _mapper.Map(request, modelToUpdate);
    _context.Services.Update(mappedRequest);
    await _context.SaveChangesAsync();

    return modelToUpdate;
  }

    public async Task<Boolean> CheckNameAvailabilityUpdateDTO(int id, ServiceDToRegister request)
  {
    // var checkDoublons = await _context.Services.AnyAsync();
    var checkDoublons = await _context.Services.Where(x => x.Name == request.Name && x.Id != id).AnyAsync();

    if (checkDoublons)
    {
      return false;
    }

    return true;
  }

}