using Microsoft.Extensions.DependencyInjection;
using BlazorApp.Server.Services;
using BlazorApp.Server.Helpers;



//DIMethod for Dependancy Injection Method

namespace BlazorApp.Server.ExtensionMethods;

public static class DIMethods
{

  #region Public methods
  public static void AddInjections(this IServiceCollection services)
  {
    // services.AddScoped<IProductRepository, DefaultProductRepository>();
    services.AddScoped<ISiteService, SiteService>();
    services.AddScoped<ISalarierService, SalarierService>();
    services.AddScoped<IServiceService, ServiceService>();
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IJwtUtils, JwtUtils>();

    // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

  }
  #endregion

}