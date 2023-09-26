using CarProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CarProject
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<CarModel> Models => Set<CarModel>();
        public DbSet<CarColor> Colors => Set<CarColor>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
