using System.Linq.Expressions;
using Common.Domain;

namespace Common.Infra.Database.Interfaces;

public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
{
    Task<bool> ExistsAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken token = default);
    Task<TAggregateRoot?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task CreateAsync(TAggregateRoot aggregate, CancellationToken token = default);
    Task<bool> CommitAsync(CancellationToken token);
}