using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Xunit;

namespace BEChallenge.Infrastructure.Test.Integration
{
    public abstract class MappingTestBase<TEntity> : IDisposable where TEntity : class
    {
        protected BEChallengeDbContext BEChallengeDbContext { get; }

        protected MappingTestBase()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<BEChallengeDbContext>().UseSqlServer(config.GetConnectionString(nameof(BEChallengeDbContext))).Options;
            this.BEChallengeDbContext = new BEChallengeDbContext(options);
        }

        [Fact]
        public virtual void Read_Entity_Mapped()
        {
            this.BEChallengeDbContext.Set<TEntity>().FirstOrDefault();
        }

        public void Dispose()
        {
            this.BEChallengeDbContext.Dispose();
        }
    }
}