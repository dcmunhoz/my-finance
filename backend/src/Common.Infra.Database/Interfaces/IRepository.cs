namespace Common.Infra.Database.Interfaces;

public interface IRepository
{
    Task<bool> CommitAsync(CancellationToken token);
}