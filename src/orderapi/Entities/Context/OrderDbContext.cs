using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.Entities.Context
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };

            //modelBuilder.ApplyConfiguration(new OwnerContextConfiguration(ids));
            //modelBuilder.ApplyConfiguration(new AccountContextConfiguration(ids));
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
