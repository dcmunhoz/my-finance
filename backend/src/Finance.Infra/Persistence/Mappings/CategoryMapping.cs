using Finance.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Database.Persistence.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("CATEGORIES");
        
        builder.HasKey(c => c.Id);

        builder.Property(p => p.Id)
            .HasColumnName("ID");
        
        builder.Property(p => p.Description)
            .HasColumnName("DESCRIPTION");
        
        builder.Property(p => p.Color)
            .HasColumnName("COLOR");
        
        builder.Property(p => p.ParentId)
            .HasColumnName("PARENTID");
        
        builder.Property(p => p.UserId)
            .HasColumnName("USERID");

        builder.HasOne(p => p.Parent)
            .WithMany()
            .HasForeignKey(p => p.ParentId);

    }
}