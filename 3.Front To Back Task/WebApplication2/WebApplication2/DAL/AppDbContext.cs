using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
