using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Configurations;

public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256); // Email için uygun bir uzunluk

        builder.HasIndex(u => u.Email)
            .IsUnique(); 
    }
}
