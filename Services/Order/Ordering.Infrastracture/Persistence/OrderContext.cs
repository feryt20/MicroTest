using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
       
        public OrderContext()
        {
        }
        public OrderContext(DbContextOptions<OrderContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///#1

            //optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=OrderDb;User Id=sa;Password=fery;Integrated Security=true;Encrypt=False;");
        }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.CreatedBy = "mohammad";
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "mohammad";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
