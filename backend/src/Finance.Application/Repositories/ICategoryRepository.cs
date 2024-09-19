using Finance.Domain.Aggregates;

namespace Finance.Application.Repositories;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category, CancellationToken cancellationToken = default);
}