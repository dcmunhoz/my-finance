using Core.Repositories;
using Finance.Application.Repositories;
using Finance.Domain.Aggregates;

namespace Finance.Infra.Persistence.Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly FinanceDbContext _context;
    
    public IUnitOfWork UnitOfWork => _context;
    
    public CategoryRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task CreateCategoryAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _context.Categories.AddAsync(category, cancellationToken);
    }
}