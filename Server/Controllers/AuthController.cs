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