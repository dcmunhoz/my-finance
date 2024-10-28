using Core.Repositories;
using Finance.Domain.Aggregates;
using Finance.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data;

public class FinanceDbContext(DbContextOptions<FinanceDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Category> Categories { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        => await base.SaveChangesAsync(cancellationToken) > 0;
}