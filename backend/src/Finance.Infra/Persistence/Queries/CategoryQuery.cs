using Finance.Application.Common.Interface.Queries;
using Finance.Contracts.Categories.Responses;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Database.Persistence.Queries;

public class CategoryQuery(FinanceDbContext context) : ICategoryQuery
{
    public async Task<CategoryResponse?> GetByIdAsync(Guid id, CancellationToken token = default)
        => await context.Categories.Include(i => i.Parent).FirstOrDefaultAsync(w => w.Id.Equals(id), token);
}