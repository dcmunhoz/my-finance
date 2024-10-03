namespace Core.Repositories;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}