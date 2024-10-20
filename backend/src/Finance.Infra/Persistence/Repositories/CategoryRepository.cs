using Core.Repositories;
using Finance.Application.Repositories;
using Finance.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Persistence.Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly FinanceDbContext _context;
    
    public IUnitOfWork UnitOfWork => _context;
    
    public CategoryRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _context.Categories.AddAsync(category, cancellationToken);
    }

    public async Task<Category> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        => await _context.Categories.FirstOrDefaultAsync(w => w.Id == Id, cancellationToken);
}