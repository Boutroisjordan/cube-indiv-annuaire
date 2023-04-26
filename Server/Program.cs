using BlazorApp.Server.Context;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BlazorApp.Server.ExtensionMethods;
using BlazorApp.Server.Helpers;
using BlazorApp.Server.Context.TypeConfigurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddInjections();
builder.Services.AddDbContext<DataContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
  options.EnableSensitiveDataLogging(true);
});

builder.Services.AddHttpContextAccessor();

var token = builder.Configuration.GetSection("AppSettings:Token").Value;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme{
    Description = "standart Authorization header using the bearer scheme ",
    In = ParameterLocation.Header,
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
  });

  options.OperationFilter<SecurityRequirementsOperationFilter>();
});
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options => 
//     { 
//       if (token != null)
//       {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//           ValidateIssuerSigningKey = true,
//           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
//           .GetBytes(token)),
//           ValidateIssuer = false,
//           ValidateAudience = false
//         };
//       }
//     });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var value = builder.Configuration.GetSection("AppSettings:Secret").Value;
        if (value != null)
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
    });

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();

}
app.UseCors(builder =>
{
  builder.AllowAnyHeader()
             .AllowAnyMethod()
             .AllowAnyOrigin(); 
});
  app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.Run();