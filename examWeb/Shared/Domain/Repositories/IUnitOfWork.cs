
namespace examWeb.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}