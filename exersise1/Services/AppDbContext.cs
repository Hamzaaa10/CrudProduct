using exersise1.Models;
using Microsoft.EntityFrameworkCore;

namespace exersise1.Services
{
    public class AppDbContext : DbContext 
    {
       public AppDbContext() : base() { }

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database = Products;Integrated Security=true;Encrypt=false");
        }
    }
}
