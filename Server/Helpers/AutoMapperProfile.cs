using BlazorApp.Shared.Models;
using AutoMapper;

namespace BlazorApp.Server.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SiteDToRegister, Site>();
        CreateMap<SiteDToUpdate, Site>();
        CreateMap<SalarierDToRegister, Salarier>();
        CreateMap<ServiceDToRegister, Service>();
    }
}
