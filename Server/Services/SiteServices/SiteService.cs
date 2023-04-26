using BlazorApp.Shared.Models;
using BlazorApp.Server.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BlazorApp.Server.Services;

public class SiteService : ISiteService
{
  #region Fields

  private readonly DataContext _context;
  private readonly IMapper _mapper;

  #endregion

  // #region Constructors
  public SiteService(DataContext context, IMapper mapper)
  {
    this._context = context;
    this._mapper = mapper;
  }

  public async Task<Site> Create(SiteDToRegister request)
  {
    // var checkDoublons = await _context.Sites.AnyAsync();
    // var checkDoublons = await _context.Sites.Where(x => x.Name == request.Name).AnyAsync();

    // if(checkDoublons) {
    //   throw new Exception($"Site with name {request.Name} already exist");
    // }

    var mappedRequest = _mapper.Map<Site>(request);
    var result = await _context.Sites.AddAsync(mappedRequest);

    if (result is null)
    {
      throw new Exception("Error create");
    }

    await _context.SaveChangesAsync();
    return result.Entity;
  }
  public async Task<Boolean> CheckNameAvailability(SiteDToRegister request)
  {
    // var checkDoublons = await _context.Sites.AnyAsync();
    var checkDoublons = await _context.Sites.Where(x => x.Name == request.Name).AnyAsync();

    if (checkDoublons)
    {
      return false;
    }

    return true;
  }
  public async Task<Boolean> CheckNameAvailabilityUpdateDTO(int id, SiteDToUpdate request)
  {
    // var checkDoublons = await _context.Sites.AnyAsync();
    var checkDoublons = await _context.Sites.Where(x => x.Name == request.Name && x.Id != id).AnyAsync();

    if (checkDoublons)
    {
      return false;
    }

    return true;
  }

  public async Task<Site> Delete(int id)
  {
    var dbresult = await _context.Sites.FindAsync(id);
    if (dbresult is null)
    {
      throw new Exception("Furnisher not found");
    }

    _context.Sites.Remove(dbresult);
    await _context.SaveChangesAsync();
    return dbresult;
  }

  public Task<List<Site>> GetAll()
  {
    var dbResult = _context.Sites.ToListAsync();

    if (dbResult is null)
    {
      throw new Exception("No sites found");
    }

    return dbResult;
  }

  public async Task<Site> GetById(int id)
  {
    var dbResult = await _context.Sites.FindAsync(id);

    if (dbResult is null)
    {
      throw new Exception("No site found");
    }

    return dbResult;
  }

  public Task<Site> GetByName(string name)
  {
    throw new NotImplementedException();
  }

  public async Task<Site> Update(int id, SiteDToUpdate request)
  {
    var modelToUpdate = await _context.Sites.Where(x => x.Id ==id).FirstOrDefaultAsync();

    if(modelToUpdate is null) {
      throw new Exception("User not found");
    }

    Site mappedRequest = _mapper.Map(request, modelToUpdate);
    _context.Sites.Update(mappedRequest);
    await _context.SaveChangesAsync();

    return modelToUpdate;
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