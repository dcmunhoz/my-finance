namespace Common.Infra.Database.Interfaces;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken token);
}