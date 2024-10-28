using Finance.Application.Queries;
using Finance.Contracts.Responses.Category;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Queries;

public sealed class CategoryQuery(FinanceDbContext dbContext) : ICategoryQuery
{
    public async Task<CategoryResponse?> GetByIdAsync(Guid id)
        => await dbContext.Categories.AsNoTracking()
                                      .Include(i => i.Childrens)
                                      .Where(w => w.Id == id)
                                      .Select(s => new CategoryResponse(s.Id, 
                                                                                s.Name, 
                                                                                s.Color,
                                                                                s.Childrens.Select(c => new ChildrenCategoryResponse(c.Id, c.Name, c.Color))))
                                      .FirstOrDefaultAsync();
}
