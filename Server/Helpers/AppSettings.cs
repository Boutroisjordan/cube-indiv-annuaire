using BlazorApp.Shared.Models;
using AutoMapper;

namespace BlazorApp.Server.Helpers;

public class AppSettings
{
    public string Secret { get; set; } = string.Empty;
}