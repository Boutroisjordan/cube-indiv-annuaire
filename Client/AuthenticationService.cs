// using BlazorApp.Shared.Models;
// using Microsoft.AspNetCore.Components;
// using System.Threading.Tasks;
// using Blazored.LocalStorage;
// using System.Net.Http.Headers;
// using System.Net.Http;
// using System.Text.Json;
// using System.Text;
// using BlazorApp.Client;

// namespace BlazorApp.Client
// {
//     public interface IAuthenticationService
//     {
//         // User User { get; }
//         Task Initialize();
//         Task Login(string username, string password);
//         Task Logout();
//     }

//     public class AuthenticationService : IAuthenticationService
//     {
//         private HttpClient _http;
//         private NavigationManager _navigationManager;
//         private ILocalStorageService _localStorage;

//         // public User User { get; private set; }

//         public AuthenticationService(
//             HttpClient http,
//             NavigationManager navigationManager,
//             ILocalStorageService localStorage
//         ) {
//             _http = http;
//             _navigationManager = navigationManager;
//             _localStorage = localStorage;
//         }

//         public async Task Initialize()
//         {
//             // User = await _localStorageService.GetItem<User>("user");
//             string token = await _localStorage.GetItemAsStringAsync("token");

//         }

//         public async Task Login(string username, string password)
//         {
//             // User = await _http.Post<User>("api/auth/login", new { username, password });
//             // await _localStorageService.SetItem("user", User);
//             var result = await _http.PostAsync<AuthenticateResponse>("api/Auth/login", new StringContent(JsonSerializer.Serialize(new { username, password }), Encoding.UTF8, "application/json"));

//             // var token = await result.Content.ReadAsStringAsync();
//             // Line($"tokenval: {token}");
//             // await LocalStorage.SetItemAsync("token", token);
//             // await AuthStateProvider.GetAuthenticationStateAsync();
//             // NavigationManager.NavigateTo("/");
//         }

//         public async Task Logout()
//         {
//             User = null;
//             await _localStorageService.RemoveItem("user");
//             _navigationManager.NavigateTo("login");
//         }
//     }
// }