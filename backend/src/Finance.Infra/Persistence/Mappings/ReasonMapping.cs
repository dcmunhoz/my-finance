using Finance.Domain.Aggregates.Reasons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Database.Persistence.Mappings;

public class ReasonMapping : IEntityTypeConfiguration<Reason>
{
    public void Configure(EntityTypeBuilder<Reason> builder)
    {
        builder.ToTable("REASONS");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID");
        builder.Property(x => x.Type).HasColumnName("TYPE");
        builder.Property(x => x.Description).HasColumnName("DESCRIPTION");
        builder.Property(x => x.Color).HasColumnName("COLOR");
    }
}