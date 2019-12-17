using EfCoreSamples.DbFirst.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace EfCoreSamples.DbFirst.Context
{
    public partial class StoreDB_3Context : DbContext
    {
        public StoreDB_3Context()
        {
        }

        public StoreDB_3Context(DbContextOptions<StoreDB_3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=EN1210001;Integrated Security=True; Initial Catalog=Demo2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
            });
        }
    }
}
