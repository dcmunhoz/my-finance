using Finance.Contracts.Responses.Category;

namespace Finance.Application.Queries;

public interface ICategoryQuery
{
    Task<CategoryResponse?> GetByIdAsync(Guid id);
}
