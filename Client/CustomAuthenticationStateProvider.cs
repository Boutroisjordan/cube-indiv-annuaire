using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using BlazorApp.Client.Extensions;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorApp.Shared.Models;
using System.Net.Http.Headers;



namespace BlazorApp.Client.Authentication;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
  // private readonly ILocalStorageService _localStorage;
  private readonly ISessionStorageService _sessionStorage;
  private readonly HttpClient _http;

  private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

  public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage, HttpClient http)
  {
    _sessionStorage = sessionStorage;
    _http = http;
  }

  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    try
    {
      var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
      if (userSession == null)
      {
        return await Task.FromResult(new AuthenticationState(_anonymous));
      }

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
    {
      new Claim(ClaimTypes.Name, userSession.UserName),
      // new Claim(ClaimTypes.Role, userSession.Role),
    }, "JwtAuth"));


      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userSession.Token);


      return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }
    catch
    {
      return await Task.FromResult(new AuthenticationState(_anonymous));
    }

  }

  public async Task UpdateAuthenticationState(UserSession? userSession)
  {
    ClaimsPrincipal claimsPrincipal;

    if(userSession != null) {
      claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
      {
        new Claim(ClaimTypes.Name, userSession.UserName),
        // new Claim(ClaimTypes.Role, userSession.Role),
      }));
      // userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpireIn);
      await _sessionStorage.SaveItemEncryptedAsync("UserSession", userSession);
    } else {
      claimsPrincipal = _anonymous;
      await _sessionStorage.RemoveItemAsync("UserSession");
    }

    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
  }
// Va chercher le token dans la session si la session existe, sinon retourne une string vide
  public async Task<string> GetToken()
  {
    var result = string.Empty;
    try{
        var userSession = await  _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
        if (userSession != null) {
          result = userSession.Token;
        }
    }
    catch { }
      return result;
  }
}
