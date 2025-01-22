namespace Common.Infra.Database.Interfaces;

public interface IRepository
{
    Task CommitAsync(CancellationToken token);
}