using Microsoft.EntityFrameworkCore;
using BlazorApp.Shared.Models;
using BlazorApp.Server.Context.TypeConfigurations;


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
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new SiteEntityConfiguration());

    }

        public DbSet<Salarier> Salariers {get; set;} = null!;
        public DbSet<Site> Sites {get; set;} = null!;
        public DbSet<Service> Services {get; set;} = null!;
        public DbSet<User> Users {get; set;} = null!;
}

