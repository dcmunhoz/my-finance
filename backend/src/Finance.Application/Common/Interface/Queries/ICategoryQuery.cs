using Finance.Contracts.Categories.Responses;

namespace Finance.Application.Common.Interface.Queries;

public interface ICategoryQuery
{
    Task<CategoryResponse?> GetByIdAsync(Guid id, CancellationToken token = default);
}