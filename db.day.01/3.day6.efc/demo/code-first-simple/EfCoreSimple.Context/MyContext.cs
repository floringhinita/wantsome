using System;

namespace EfCoreSimple.Context
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class MyContext : DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EN1210001;Integrated Security=True; Initial Catalog=StoreDB;");
        }
    }
}
