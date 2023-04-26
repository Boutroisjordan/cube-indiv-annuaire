
namespace BlazorApp.Shared.Models;


public class Salarier {
  public int Id {get; set;}
  public string? first_name {get; set;}
  public string? last_name {get; set;}
  public string? fixPhone {get; set;}
  public string? portablePhone {get; set;}
  public string? email {get; set;}
  
  public int siteId {get; set;}
  public Site? site {get; set;}
  public int serviceId {get; set;}
  public Service? service {get; set;}
  // string serviceFK {get; set:}
  // string siteFK {get; set:}
}

public class SalarierDToRegister {
    public string? first_name {get; set;}
  public string? last_name {get; set;}
  public string? fixPhone {get; set;}
  public string? portablePhone {get; set;}
  public string? email {get; set;}
  public int siteId {get; set;}
  public int serviceId {get; set;}


}



