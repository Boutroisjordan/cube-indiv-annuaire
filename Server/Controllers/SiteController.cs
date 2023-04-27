using Microsoft.AspNetCore.Mvc;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Server.Controllers;

using BlazorApp.Server.Services;

[Route("api/[controller]")]
[ApiController]
public class SiteController : ControllerBase
{
    #region Fields

    private ISiteService _siteService;
    #endregion

    #region Constructor

    public SiteController(ISiteService siteService)
    {
        _siteService = siteService;
    }

    #endregion

    #region methods

    /// <summary>
    /// Récupère tous les sites
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _siteService.GetAll();

        if(result.Count() <= 0) {
            return NoContent();
        }
        return Ok(result);
    }
    // // [HttpGet]
    // // public async Task<IActionResult> GetAll()
    // // {
       
    // //     return Ok();
    // // }

    // /// <summary>
    // /// Récupère tous les types d'alcool
    // /// </summary>
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _siteService.GetById(id);

        return Ok(result);
    }


  // /// <summary>
  // /// Créer un type d'alcool
  // /// </summary>
  // // [Authorize(Roles = "Admin")]
  [HttpPost, Authorize]
    public async Task<IActionResult> Add(SiteDToRegister request)
    {
        var checkAvailability = await _siteService.CheckNameAvailability(request);

        if(!checkAvailability) {
            return BadRequest($"Site with name '{request.Name}' already exist.");
        }
        var result = await _siteService.Create(request);
        
        return Ok(result);
    }

  // /// <summary>
  // /// Met à jour un type d'alcool
  // /// </summary>
  // // [Authorize(Roles = "Admin")]
  [HttpPut, Authorize]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, SiteDToUpdate request)
    {
        var checkAvailability = await _siteService.CheckNameAvailabilityUpdateDTO(id, request);

        if(!checkAvailability) {
            return BadRequest($"Site with name '{request.Name}' already exist.");
        }
        var result = await _siteService.Update(id, request);
        
        return Ok(result);
    }

    // /// <summary>
    // /// Supprime le site
    // /// </summary>
    // // [Authorize(Roles = "Admin")]
    [HttpDelete]
  [Route("{id}"), Authorize]
    public async Task<IActionResult> Delete(int id)
    {

    var result = await _siteService.Delete(id);
        // return Ok({message: "", infos: result});
        return Ok(result);
    }

    #endregion
}