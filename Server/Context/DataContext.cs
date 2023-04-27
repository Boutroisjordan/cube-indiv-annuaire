using Microsoft.EntityFrameworkCore;
using BlazorApp.Shared.Models;
using BlazorApp.Server.Context.TypeConfigurations;
using Bogus;


namespace BlazorApp.Server.Context;

public class DataContext : DbContext
{
  #region Constructor

  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {
  }

  #endregion

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.ApplyConfiguration(new SiteEntityConfiguration());

    List<Service> serviceList = new List<Service> {
        new Service { Id = 1, Name = "Ressources humaines" },
        new Service { Id = 2, Name = "Informatique" },
        new Service { Id = 3, Name = "Comptabilité" },
        new Service { Id = 4, Name = "Production" },
        new Service { Id = 5, Name = "Accueil" },
        new Service { Id = 6, Name = "Commercial" }
    };
    List<Site> siteList = new List<Site> {
        new Site { Id = 1, Name = "Paris" },
        new Site { Id = 2, Name = "Toulouse" },
        new Site { Id = 3, Name = "Lille" },
        new Site { Id = 4, Name = "Nantes" },
        new Site { Id = 5, Name = "Nice" }
    };
    modelBuilder.Entity<Service>().HasData(serviceList);

    modelBuilder.Entity<Site>().HasData(siteList);

    var faker = new Faker<Salarier>("fr")
    .RuleFor(c => c.Id, f => f.IndexFaker + 1)
    .RuleFor(p => p.first_name, f => f.Name.FirstName())
    .RuleFor(p => p.last_name, f => f.Name.LastName())
    .RuleFor(p => p.fixPhone, f => f.Phone.PhoneNumber())
    .RuleFor(p => p.portablePhone, f => f.Phone.PhoneNumber())
    .RuleFor(p => p.email, f => f.Internet.Email())
    .RuleFor(c => c.serviceId, f => f.PickRandom(serviceList).Id)
    .RuleFor(c => c.siteId, f => f.PickRandom(siteList).Id);

    modelBuilder.Entity<Salarier>().HasData(faker.Generate(1000));
    base.OnModelCreating(modelBuilder);

  }

  public DbSet<Salarier> Salariers { get; set; } = null!;
  public DbSet<Site> Sites { get; set; } = null!;
  public DbSet<Service> Services { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;
}

