using System.Linq.Expressions;
using Finance.Application.Common.Interface.Repository;
using Finance.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Database.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly FinanceDbContext _context;

    public CategoryRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(Expression<Func<Category, bool>> predicate, CancellationToken token = default)
        => await _context.Categories.AnyAsync(predicate, token);

    public async Task CreateAsync(Category category, CancellationToken token = default)
    {
        await _context.Categories.AddAsync(category, token);
    }

    public async Task CommitAsync(CancellationToken token)
    {
        await _context.SaveChangesAsync(token);
    }
}