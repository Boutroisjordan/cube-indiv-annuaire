using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class Site {
  [Key]
  public int Id {get; set;}
  [Key]
  public string? Name {get; set;}
  [JsonIgnore]
  public List<Salarier>? Salariers {get; set;}

}
public class SiteDToRegister {
  public string? Name {get; set;}

}
public class SiteDToUpdate {

  public string? Name {get; set;}

}

