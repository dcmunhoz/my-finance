using Finance.Contracts.Categories.Responses.Category;

namespace Finance.Application.Queries;

public interface ICategoryQuery
{
    Task<CategoryResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default); 
}
