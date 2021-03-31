using Ums.Application.Interfaces;
using Ums.Infrastructure.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Ums.Domain.Common;
using Ums.Domain.Entities;
using Ums.Infrastructure.Persistence.Configurations;

namespace Ums.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService dateTime;
        private readonly IAuthenticatedUserService authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTime,
            IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.dateTime = dateTime;
            this.authenticatedUser = authenticatedUser;
        }

        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = dateTime.NowUtc;
                        entry.Entity.CreatedBy = authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = authenticatedUser.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());

            builder.Seed();
            //base.OnModelCreating(builder);
        }
    }
}