using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
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
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    productID = 1,
                    productName = "Adidas shoes",
                    price = 200,
                    brand = "Adidas",
                    category = Category.Shoes,
                    discountPercentage = 20,
                    imgURL = "~/images/adidas_shoes.jpg",
                },
                new Product()
                {
                    productID = 2,
                    productName = "Nike shoes",
                    price = 100,
                    brand = "Nike",
                    category = Category.Shoes,
                    discountPercentage = 30,
                    imgURL = "~/images/nike_carousel.jpg",
                },
                new Product()
                {
                    productID = 3,
                    productName = "Coolmate Box",
                    price = 250,
                    brand = "Coolmate",
                    category = Category.Pant,
                    discountPercentage = 30,
                    imgURL = "~/images/coolmate_mkt.jpg",
                },
                new Product()
                {
                    productID = 4,
                    productName = "Nike Combo",
                    price = 400,
                    brand = "Nike",
                    category = Category.Shirt,
                    discountPercentage = 20,
                    imgURL = "~/images/nike_mkt.jpg",
                },
                new Product()
                {
                    productID = 5,
                    productName = "No name",
                    price = 150,
                    brand = "Other",
                    category = Category.Pant,
                    discountPercentage = 30,
                    imgURL = "~/images/OIP.jpg",
                },
                new Product()
                {
                    productID = 6,
                    productName = "1842 T-shirt",
                    price = 200,
                    brand = "Other",
                    category = Category.Shirt,
                    discountPercentage = 20,
                    imgURL = "~/images/T-shirt.jpg",
                },
                new Product()
                {
                    productID = 7,
                    productName = "Hunter shoes",
                    price = 100,
                    brand = "Other",
                    category = Category.Shoes,
                    discountPercentage = 30,
                    imgURL = "~/images/giay.jpg",
                });


            modelBuilder.Entity<Payment>();
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
            },
            new IdentityRole
            {
                Id = "6bc135f7-455c-4b04-b301-f32642221dea",
                Name = "Customer",
                NormalizedName = "CUSTOMER".ToUpper()
            }
            );


            /*var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
               new IdentityUser
               {
                   Id = "c28305c3-93f5-4490-ae59-05d0401bcee3",
                   UserName = "Super Admin",
                   NormalizedUserName = "SUPER ADMIN".ToUpper(),
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin@123")
               }*/


            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   Id = "c28305c3-93f5-4490-ae59-05d0401bcee3",
                   UserName = "Super Admin",
                   NormalizedUserName = "SUPER ADMIN".ToUpper(),
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin@123"),
                   Address = "SGU",
                   Fristname = "Duong",
                   Lastname = "Van Tri",
                   Phone = "123"
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
