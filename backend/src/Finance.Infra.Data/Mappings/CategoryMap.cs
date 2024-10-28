using Finance.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("CATEGORY");

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("ID") 
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired();
        
        builder.Property(p => p.Name)
            .HasColumnName("NAME")
            .HasColumnType("VARCHAR(10)")
            .IsRequired();
        
        builder.Property(p => p.Color)
            .HasColumnName("COLOR")
            .HasColumnType("VARCHAR(10)")
            .IsRequired();
        
        builder.Property(p => p.ParentId)
            .HasColumnName("PARENTID")
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired(false);

        builder.HasMany(p => p.Childrens)
            .WithOne()
            .HasForeignKey(p => p.ParentId);
    }
}