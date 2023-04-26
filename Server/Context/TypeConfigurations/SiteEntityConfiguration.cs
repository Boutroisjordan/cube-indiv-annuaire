using Microsoft.EntityFrameworkCore;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Server.Context.TypeConfigurations;

class SiteEntityConfiguration : IEntityTypeConfiguration<Site>
{
    #region Public methods
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        //Nom de la tabmle
        builder.ToTable("Site");
        //Primary key de la table
        builder.HasKey(item => item.Id);


    }
    #endregion

}
