namespace Common.Infra.Database.Interfaces;

public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken token);
}