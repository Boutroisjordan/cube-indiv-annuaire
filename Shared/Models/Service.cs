using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class Service {
  public int Id {get; set;}
  public string? Name {get; set;}
[JsonIgnore]
  public List<Salarier>? Salariers {get; set;}
}

public class ServiceDToRegister {
  public string? Name {get; set;}

}

