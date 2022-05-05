using BEChallenge.Domain;
using BEChallenge.Domain.Entities;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace BEChallenge.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Members

        private readonly BEChallengeDbContext dbContext;
        private IRepository<User> userRepository;
        #endregion

        #region Constructors

        public UnitOfWork(BEChallengeDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion

        #region Properties

        public IRepository<User> UserRepository => this.userRepository ?? (this.userRepository = new Repository<User>(this.dbContext));
        #endregion

        #region Methods

        public async Task<IEnumerable<T>> QueryAsync<T>(String query, Object parameter)
        {
            var connection = this.dbContext.Database.GetDbConnection();
            return await connection.QueryAsync<T>(query, parameter);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            using (TransactionScope transactionScope = CreateTransaction())
            {
                await this.dbContext.SaveChangesAsync(cancellationToken);
                transactionScope.Complete();
            }
            try
            {
                // events
            }
            catch
            {

            }
        }

        private static TransactionScope CreateTransaction()
        {
            return new TransactionScope(TransactionScopeOption.Required,
                                        new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted, Timeout = TimeSpan.FromMinutes(30) },
                                        TransactionScopeAsyncFlowOption.Enabled);
        }

        #endregion
    }
}