using Core.Repositories;
using Finance.Domain.Aggregates;

namespace Finance.Application.Repositories;

public interface ICategoryRepository : IRepository
{
    Task CreateCategoryAsync(Category category, CancellationToken cancellationToken = default);
}