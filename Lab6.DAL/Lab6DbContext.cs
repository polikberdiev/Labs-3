using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lab6.Domain;
using Lab6.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.DAL
{
    public class Lab6DbContext : DbContext
    {
        private static DbContextOptions<Lab6DbContext> Options
        {
            get
            {
                var options = new DbContextOptionsBuilder<Lab6DbContext>();
                options.UseSqlServer("Data Source=(local);Initial Catalog=Lab6Db;Integrated Security=True");

                return options.Options;
            }
        }


        public Lab6DbContext()
            : base(Options) { }

        public Lab6DbContext(DbContextOptions options)
            : base(options) { }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            foreach (var entityEntry in ChangeTracker.Entries<IStateModel>().Where(e => e.State == EntityState.Deleted))
            {
                entityEntry.State = EntityState.Modified;
                entityEntry.Entity.State = State.Deleted;
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().ToTable("Accounts");
            modelBuilder.Entity<AccountModel>().HasOne(a => a.AccountType);
            modelBuilder.Entity<AccountModel>().HasOne(a => a.OwnerUser);

            modelBuilder.Entity<AccountTypeModel>().ToTable("AccountTypes");

            modelBuilder.Entity<UserModel>().ToTable("Users");

            base.OnModelCreating(modelBuilder);
        }
    }
}