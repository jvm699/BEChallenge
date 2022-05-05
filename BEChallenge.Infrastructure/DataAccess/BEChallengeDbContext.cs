using BEChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BEChallenge.Infrastructure
{
    public class BEChallengeDbContext : DbContext
    {
        #region Constructors
        public BEChallengeDbContext(DbContextOptions<BEChallengeDbContext> options) 
            : base(options)
        {

        }

        #endregion

        #region Properties

        public DbSet<User> User { get; set; }

        #endregion

        #region Methods

        public override System.Int32 SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<System.Int32> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BEChallengeDbContext)));
        }

        #endregion
    }
}
