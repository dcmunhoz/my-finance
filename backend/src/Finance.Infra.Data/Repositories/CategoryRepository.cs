using Core.Repositories;
using Finance.Application.Repositories;
using Finance.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories;

public sealed class CategoryRepository(FinanceDbContext context) : ICategoryRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Categories.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

    public async Task CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        await context.Categories.AddAsync(category, cancellationToken);
    }
}