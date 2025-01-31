using Finance.Contracts.Categories.Responses;

namespace Finance.Application.Common.Interface.Queries;

public interface ICategoryQuery
{
    Task<CategoryResponse?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<CategoriesResponse>> GetAllAsync(CancellationToken token = default);
}