using Microsoft.EntityFrameworkCore;
using ParcelDeliverySystem.Models;

namespace ParcelDeliverySystem.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Recipient> Recipients { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ShipmentStatus> ShipmentStatuses { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("pgcrypto");

        // ROLES 

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.RoleId);

            entity.Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(30);
        });

        // USERS

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.UserId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.HasIndex(u => u.Email)
                .IsUnique();

            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // RECIPIENTS 

        modelBuilder.Entity<Recipient>(entity =>
        {
            entity.HasKey(r => r.RecipientId);

            entity.Property(r => r.RecipientId)
                .HasDefaultValueSql("gen_random_uuid()");
        });

        // SHIPMENT STATUS

        modelBuilder.Entity<ShipmentStatus>(entity =>
        {
            entity.HasKey(s => s.StatusId);
        });

        // BRANCHES

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(b => b.BranchId);
        });

        // SHIPMENTS

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(s => s.ShipmentId);

            entity.Property(s => s.ShipmentId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(s => s.Price)
                .HasColumnType("decimal(10,2)");

            entity.HasOne(s => s.User)
                .WithMany(u => u.Shipments)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Recipient)
                .WithMany(r => r.Shipments)
                .HasForeignKey(s => s.RecipientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Status)
                .WithMany(st => st.Shipments)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(s => s.OriginBranch)
                .WithMany()
                .HasForeignKey(s => s.BranchFrom)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(s => s.DestinationBranch)
                .WithMany()
                .HasForeignKey(s => s.BranchTo)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // PACKAGES

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(p => p.PackageId);

            entity.Property(p => p.PackageId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(p => p.Weight)
                .HasColumnType("decimal(10,2)");

            entity.HasOne(p => p.Shipment)
                .WithMany(s => s.Packages)
                .HasForeignKey(p => p.ShipmentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        // DATA SEEDING

        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, RoleName = "SuperAdmin" },
            new Role { RoleId = 2, RoleName = "BranchAdmin" },
            new Role { RoleId = 3, RoleName = "Employee" }
        );

        modelBuilder.Entity<ShipmentStatus>().HasData(
            new ShipmentStatus { StatusId = 1, StatusName = "CREATED", Description = "El envío ha sido creado." },
            new ShipmentStatus { StatusId = 2, StatusName = "IN_TRANSIT", Description = "El envío está en camino." },
            new ShipmentStatus { StatusId = 3, StatusName = "DELIVERED", Description = "El envío ha sido entregado." }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "Super Admin",
                Phone = "00000000",
                Email = "admin@system.com",
                Password = "$2a$12$d3dwKQXdFPkVmOzY7mQ/k.PR/h7tqhZYqdpSLrBl0ydpJXRH2FJp.",
                RoleId = 1
            }
        );
    }
}