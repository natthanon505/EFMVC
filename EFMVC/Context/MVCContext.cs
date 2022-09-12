using EFMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMVC.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerOrderItem> CustomerOrderItems { get; set; }

    }
}