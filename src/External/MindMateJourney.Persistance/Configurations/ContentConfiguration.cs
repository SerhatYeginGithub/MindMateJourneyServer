using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Configurations;

public sealed class ContentConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasColumnType("nvarchar(max)");

        builder.Property(c => c.CategoryId)
            .IsRequired();

        builder.HasOne(c => c.Category)
            .WithMany(c => c.Contents)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Contents");
    }
}
