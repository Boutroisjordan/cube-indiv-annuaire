using BlazorApp.Shared.Models;
using BlazorApp.Server.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BlazorApp.Server.Services;

public class SalarierService : ISalarierService
{
  #region Fields

  private readonly DataContext _context;
  private readonly IMapper _mapper;

  #endregion

  // #region Constructors
  public SalarierService(DataContext context, IMapper mapper)
  {
    this._context = context;
    this._mapper = mapper;
  }

  public async Task<Salarier> Create(SalarierDToRegister request)
  {
    // var checkDoublons = await _context.Sites.AnyAsync();
    // var checkDoublons = await _context.Sites.Where(x => x.Name == request.Name).AnyAsync();

    // if(checkDoublons) {
    //   throw new Exception($"Site with name {request.Name} already exist");
    // }

    var mappedRequest = _mapper.Map<Salarier>(request);
    var result = await _context.Salariers.AddAsync(mappedRequest);

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
  //   var checkDoublons = await _context.Salariers.Where(x => x.Name == request.Name).AnyAsync();

  //   if (checkDoublons)
  //   {
  //     return false;
  //   }

  //   return true;
  // }

  public async Task<Salarier> Delete(int id)
  {
    var dbresult = await _context.Salariers.FindAsync(id);
    if (dbresult is null)
    {
      throw new Exception("Furnisher not found");
    }

    _context.Salariers.Remove(dbresult);
    await _context.SaveChangesAsync();
    return dbresult;
  }

  public async Task<List<Salarier>> GetAll()
  {
    // var dbResult = _context.Salariers.ToListAsync();
    var dbResult = await _context.Salariers.Include(x => x.service).Include(x => x.site).ToListAsync();


    if (dbResult is null)
    {
      throw new Exception("No sites found");
    }

    return dbResult;
  }

  public async Task<Salarier> GetById(int id)
  {
    var dbResult = await _context.Salariers.Include(x => x.service).Where(y => y.Id == id).FirstOrDefaultAsync();

    if (dbResult is null)
    {
      throw new Exception("No site found");
    }

    return dbResult;
  }

  public Task<Salarier> GetByName(string name)
  {
    throw new NotImplementedException();
  }

  public async Task<Salarier> Update(int id, SalarierDToRegister request)
  {
    var modelToUpdate = await _context.Salariers.Where(x => x.Id ==id).FirstOrDefaultAsync();

    if(modelToUpdate is null) {
      throw new Exception("User not found");
    }

    Salarier mappedRequest = _mapper.Map(request, modelToUpdate);
    _context.Salariers.Update(mappedRequest);
    await _context.SaveChangesAsync();

    return modelToUpdate;
  }


    public async Task<Boolean> CheckEmailAvailabilityUpdateDTO(int id, SalarierDToRegister request)
  {
    // var checkDoublons = await _context.Services.AnyAsync();
    var checkDoublons = await _context.Salariers.Where(x => x.email == request.email && x.Id != id).AnyAsync();

    if (checkDoublons)
    {
      return false;
    }

    return true;
  }


  // public async Task<List<Site>> GetAll()
  // {
  //     throw new Exception("default");
  // }


  // public async Task<Site> GetById(int id)
  // {
  // }

  // public async Task<Site> GetByName(string name)
  // {
  // }



  // public async Task<Site> Update(int id, Site request)
  // {
  // }


  // public async Task<Site> Delete(int id)
  // {
  // }
}