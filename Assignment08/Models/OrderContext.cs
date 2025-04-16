using Microsoft.EntityFrameworkCore;

namespace Assignment8.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Goods> Goods { get; set; }
    }
}
