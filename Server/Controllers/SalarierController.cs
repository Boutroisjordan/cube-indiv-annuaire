using Microsoft.AspNetCore.Mvc;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Server.Controllers;

using BlazorApp.Server.Services;

[ApiController]
[Route("api/[controller]")]
public class SalarierController : ControllerBase
{
    #region Fields
    private ISalarierService _salarierService;
    #endregion

    #region Constructor
    public SalarierController(ISalarierService salarierService)
    {
        _salarierService = salarierService;
    }

    #endregion

    #region methods

    /// <summary>
    /// Récupère tous les sites
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _salarierService.GetAll();

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
        var result = await _salarierService.GetById(id);

        return Ok(result);
    }

    // /// <summary>
    // /// Récupère un site par son nom
    // /// </summary>
    // [HttpGet]
    // [Route("name/{label}")]
    // public async Task<IActionResult> GetByLabel(string label)
    // {
    //     return Ok();
    // }

    // /// <summary>
    // /// Créer un type d'alcool
    // /// </summary>
    // // [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Add(SalarierDToRegister request)
    {
        // var checkAvailability = await _salarierService.CheckNameAvailability(request);

        // if(!checkAvailability) {
        //     return BadRequest($"Site with name '{request.Name}' already exist.");
        // }
        var result = await _salarierService.Create(request);
        
        return Ok(result);
    }

    // /// <summary>
    // /// Met à jour un type d'alcool
    // /// </summary>
    // // [Authorize(Roles = "Admin")]
   [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, SalarierDToRegister request)
    {
        var checkAvailability = await _salarierService.CheckEmailAvailabilityUpdateDTO(id, request);

        if(!checkAvailability) {
            return BadRequest($"salarier with name '{request.email}' already exist.");
        }
        var result = await _salarierService.Update(id, request);
        
        return Ok(result);
    }

    // /// <summary>
    // /// Supprime le site
    // /// </summary>
    // // [Authorize(Roles = "Admin")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      
        var result = await _salarierService.Delete(id);
        // Console.WriteLine($"DELETE: {result.Name}");
        // return Ok({message: "", infos: result});
        return Ok(result);
    }

    #endregion
}