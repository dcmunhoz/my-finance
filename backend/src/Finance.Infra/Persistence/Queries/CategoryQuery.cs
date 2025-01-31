using Finance.Application.Common.Interface.Queries;
using Finance.Contracts.Categories.Responses;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Database.Persistence.Queries;

public class CategoryQuery(FinanceDbContext context) : ICategoryQuery
{
    public async Task<CategoryResponse?> GetByIdAsync(Guid id, CancellationToken token = default)
        => await context.Categories.Include(i => i.Parent)
                                      .FirstOrDefaultAsync(w => w.Id.Equals(id), token);

    public async Task<IEnumerable<CategoriesResponse>> GetAllAsync(CancellationToken token = default)
        => await context.Categories.Include(i => i.Children)
                                    .Where(s => s.Level.Equals(1))
                                    .Select(s => new CategoriesResponse
                                    {
                                        Id = s.Id,
                                        Description = s.Description,
                                        Color = s.Color,
                                        Type = s.Type,
                                        Childrens = s.Children.Select(s =>
                                            new ChildrenResponse(
                                                s.Id,
                                                s.Description,
                                                s.Color)),
                                    })
                                   .ToListAsync(token);
}