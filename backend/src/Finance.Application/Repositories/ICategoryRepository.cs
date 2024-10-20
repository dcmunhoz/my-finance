using Core.Repositories;
using Finance.Domain.Aggregates;

namespace Finance.Application.Repositories;

public interface ICategoryRepository : IRepository
{
    Task<Category> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task CreateAsync(Category category, CancellationToken cancellationToken = default);
}