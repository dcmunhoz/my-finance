using System.Linq.Expressions;
using Common.Infra.Database.Interfaces;
using Finance.Domain.Categories;

namespace Finance.Application.Common.Interface.Repository;

public interface ICategoryRepository : IRepository
{
    Task<bool> ExistsAsync(Expression<Func<Category, bool>> predicate, CancellationToken token = default);
    Task<Category?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task CreateAsync(Category category, CancellationToken token = default);
}