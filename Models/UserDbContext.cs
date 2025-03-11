using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Platform.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configure Product-CartItem relationship
                modelBuilder.Entity<Product>()
                    .HasMany(p => p.CartItems)
                    .WithOne(ci => ci.Product)
                    .HasForeignKey(ci => ci.ProductId);


            // Configure User-Order relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
            }


        public DbSet<User> Users { get; set; }
        public DbSet<Product>Products { get; set; }

        public DbSet<Order>Orders { get; set; }

        public DbSet<CartItem>CartItems { get; set; }

        public DbSet<Admin>Admins { get; set; }


    }
}
