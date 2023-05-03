using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetail>().HasKey(x => new {x.productID, x.orderID});
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "fff5caad-d740-48f7-abdc-03ae0635c08b",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
            new IdentityRole
            {
                Id = "be3e451c-0914-443c-897e-cba2eb45b564",
                Name = "Manager",
                NormalizedName = "MANAGER".ToUpper()
            }
            );
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
               new IdentityUser
               {
                   Id = "c28305c3-93f5-4490-ae59-05d0401bcee3",
                   UserName = "Super Admin",
                   NormalizedUserName = "SUPER ADMIN".ToUpper(),
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin@123")
               }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    UserId = "c28305c3-93f5-4490-ae59-05d0401bcee3",
                    RoleId = "fff5caad-d740-48f7-abdc-03ae0635c08b"
                },
                new IdentityUserRole<string>
                {
                    UserId = "c28305c3-93f5-4490-ae59-05d0401bcee3",
                    RoleId = "be3e451c-0914-443c-897e-cba2eb45b564"
                }
            );
        }
    }
}
