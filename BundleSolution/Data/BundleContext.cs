using BundleSolution.Model;
using Microsoft.EntityFrameworkCore;

namespace BundleSolution.Data
{
    public class BundleContext : DbContext
    {
        public DbSet<BundleEntity> Bundles { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BundleEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //update the proper connection string to add the data to it, we could maintain the connection string in the config file but for time being I am hard coding here.
            optionsBuilder.UseSqlServer("Server=.;Database=bundledb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
