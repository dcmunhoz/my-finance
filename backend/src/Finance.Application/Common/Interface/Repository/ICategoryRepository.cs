using Common.Infra.Database.Interfaces;
using Finance.Domain.Categories;

namespace Finance.Application.Common.Interface.Repository;

public interface ICategoryRepository : IRepository
{
    Task CreateAsync(Category category, CancellationToken token = default);
}