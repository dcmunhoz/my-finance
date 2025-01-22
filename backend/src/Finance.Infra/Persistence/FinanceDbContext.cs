using System.Collections.Immutable;
using System.Reflection;
using Common.Infra.Database.Interfaces;
using Finance.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Database.Persistence;

public class FinanceDbContext : DbContext, IUnitOfWork
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }
    
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }

    public async Task CommitAsync(CancellationToken token)
    {
        await SaveChangesAsync(token);
    }
}