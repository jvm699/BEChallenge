using BEChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BEChallenge.Infrastructure.EntityTypeConfiguration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);

            builder.Property(e => e.Name).HasColumnName("Name").IsRequired();
            builder.Property(e => e.BirthDate).HasColumnName("BirthDate").IsRequired();
            builder.Property(e => e.Active).HasColumnName("Active").IsRequired();

        }
    }
}