using System;
using Microsoft.EntityFrameworkCore;

namespace Task18_BootcampRefactory.Model
{
    public class Task18Context : DbContext
    {
        public Task18Context(DbContextOptions<Task18Context> opt): base(opt) { }

        public DbSet<Customers> customers { get; set; }
        public DbSet<Customers_Payment_Card> customerPayCard { get; set; }
        public DbSet<Merchant> merchants { get; set; }
        public DbSet<Products> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customers_Payment_Card>()
                .HasOne(x => x.customer)
                .WithMany()
                .HasForeignKey(x => x.customer_id);
            modelBuilder
                .Entity<Products>()
                .HasOne(x => x.merchant)
                .WithMany()
                .HasForeignKey(x => x.merchant_id);
        }
    }
}
