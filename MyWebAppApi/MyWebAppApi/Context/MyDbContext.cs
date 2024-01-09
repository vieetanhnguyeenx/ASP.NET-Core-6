using Microsoft.EntityFrameworkCore;
using MyWebAppApi.Entity;

namespace MyWebAppApi.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
