using System.Linq.Expressions;
using Finance.Application.Common.Interface.Repository;
using Finance.Domain.Aggregates.Reasons;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Database.Persistence.Repositories;

public class ReasonRepository : IReasonRepository
{
    private readonly FinanceDbContext _context;

    public ReasonRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync(CancellationToken token)
        => await _context.CommitAsync(token);

    public async Task<bool> ExistsAsync(Expression<Func<Reason, bool>> predicate, CancellationToken token = default)
        => await _context.Reasons.AnyAsync(predicate, token);

    public Task<Reason?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Reason aggregate, CancellationToken token = default)
        => await _context.Reasons.AddAsync(aggregate, token);
}