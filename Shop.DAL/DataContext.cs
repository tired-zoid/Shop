
using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.DAL  
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
