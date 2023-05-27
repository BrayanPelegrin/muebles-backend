using Microsoft.EntityFrameworkCore;
using MueblesDiamante.Models.Entities;
using System.Reflection;

namespace MueblesDiamante.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        }

    }
}
