using System.Collections.Immutable;
using System.Reflection;
using BaseAuthentication.Services;
using Common.Infra.Database.Interfaces;
using Finance.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Database.Persistence;

public class FinanceDbContext : DbContext, IUnitOfWork
{
    private readonly ITokenService _tokenService;

    public FinanceDbContext(DbContextOptions<FinanceDbContext> options, ITokenService tokenService) : base(options)
    {
        _tokenService = tokenService;
    }
    
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Category>().HasQueryFilter(w => w.UserId == _tokenService.GetUserId());
        
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> CommitAsync(CancellationToken token)
        => await SaveChangesAsync(token) > 0;
}