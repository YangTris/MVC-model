using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> account { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Product> product { get; set; }
    }
}
