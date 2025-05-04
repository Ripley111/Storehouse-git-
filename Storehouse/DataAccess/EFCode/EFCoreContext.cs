using DataAccess.EFClasses;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCode
{
    public class EFCoreContext(DbContextOptions<EFCoreContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<ProductStorage> ProductStorages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStorage>()
                .HasKey(ps => new { ps.ProductId, ps.StorageId });

            modelBuilder.Entity<ProductStorage>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductStorages)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductStorage>()
                .HasOne(ps => ps.Storage)
                .WithMany(s => s.ProductStorages)
                .HasForeignKey(ps => ps.StorageId);
        }
    }
}
