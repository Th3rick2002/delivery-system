using Microsoft.EntityFrameworkCore;
using ParcelDeliverySystem.Models;

namespace ParcelDeliverySystem.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Customer>()
            .Property(c => c.CustomerId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
        modelBuilder.Entity<Shipment>()
            .Property(s => s.ShipmentId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        modelBuilder.Entity<Shipment>()
            .HasOne(s => s.ShipmentStatus)
            .WithMany(s => s.Shipments)
            .HasForeignKey(s => s.ShipmentStatusId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Shipment>()
            .HasOne(r => r.Recipient)
            .WithMany(r => r.Shipments)
            .HasForeignKey(r => r.RecipientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Shipment>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.Shipments)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Package>()
            .HasOne(p => p.Shipment)
            .WithMany(s => s.Packages)
            .HasForeignKey(p => p.ShipmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}