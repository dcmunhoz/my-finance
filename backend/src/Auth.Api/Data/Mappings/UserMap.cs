using Auth.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Api.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("USERS");

        builder.HasKey(k => k.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("ID");

        builder.Property(p => p.Username)
            .HasColumnName("USERNAME");

        builder.Property(p => p.Name)
            .HasColumnName("NAME");

        builder.Property(p => p.Email)
            .HasColumnName("EMAIL");
    }
}