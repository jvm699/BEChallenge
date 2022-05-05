using BEChallenge.Domain.Entities;

namespace BEChallenge.Domain
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> QueryAsync<T>(String query, Object parameter);

        IRepository<User> UserRepository { get; }
    }
}
