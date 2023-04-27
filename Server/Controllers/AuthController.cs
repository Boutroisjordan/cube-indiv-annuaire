using Microsoft.AspNetCore.Mvc;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Server.Controllers;

using BlazorApp.Server.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    #region Fields
    private IUserService _userService;
    #endregion

    #region Constructor
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    #region methods

    // [HttpPost("register"), Authorize]
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDToLogin request)
    {
        var result = await _userService.Register(request);

        if(result is null) {
            return BadRequest();
        }
        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserDToLogin request)
    {
        // var result = await _userService.Login(request);
        var result = await _userService.Authenticate(request);

        if(result is null) {
      return BadRequest("Bad Crendentials");
        }
        return Ok(result);
    }

    [HttpGet("test"), Authorize]
    public IActionResult GetTest()
    {
       
        return Ok("niquel ma gueule");
    }
    [HttpGet("ValidateToken"), Authorize]
    public IActionResult GetValidate()
    {
       
        return Ok("niquel c valide");
    }


    // /// <summary>
    // /// Récupère tous les types d'alcool
    // /// </summary>
    // [HttpGet]
    // [Route("{id}")]
    // public async Task<IActionResult> GetById(int id)
    // {
    //     var result = await _userService.GetById(id);

    //     return Ok(result);
    // }

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
    // [HttpPost]
    // public async Task<IActionResult> Add(SalarierDToRegister request)
    // {
    //     // var checkAvailability = await _userService.CheckNameAvailability(request);

    //     // if(!checkAvailability) {
    //     //     return BadRequest($"Site with name '{request.Name}' already exist.");
    //     // }
    //     var result = await _userService.Create(request);
        
    //     return Ok(result);
    // }

    // /// <summary>
    // /// Met à jour un type d'alcool
    // /// </summary>
    // // [Authorize(Roles = "Admin")]
    // [HttpPut]
    // [Route("{id}")]
    // public async Task<IActionResult> Update(int id, Site request)
    // {


    //     return Ok();
    // }

    // /// <summary>
    // /// Supprime le site
    // /// </summary>
    // // [Authorize(Roles = "Admin")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

    var result = await _userService.Delete(id);
        // return Ok({message: "", infos: result});

        if(result is null) {
            return BadRequest("User not found");
        }
        return Ok(result);
    }

    #endregion
}