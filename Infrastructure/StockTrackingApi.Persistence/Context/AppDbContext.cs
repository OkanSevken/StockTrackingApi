using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<PartBrandModel> PartBrandModels { get; set; }
        public DbSet<CarBrandModel> CarBrandModels { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<CarPart> CarParts { get; set; }
        public DbSet<PartMovement> PartMovements { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehousePart> WarehouseParts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Part>()
                .HasOne(p => p.PartBrandModel)
                .WithMany()
                .HasForeignKey(p => p.ModelId);

            modelBuilder.Entity<WarehousePart>()
                .HasOne(wp => wp.Warehouse)
                .WithMany()
                .HasForeignKey(wp => wp.WarehouseId);

            modelBuilder.Entity<WarehousePart>()
                .HasOne(wp => wp.Part)
                .WithMany()
                .HasForeignKey(wp => wp.PartId);

            modelBuilder.Entity<PartMovement>()
                .HasOne(pm => pm.Part)
                .WithMany()
                .HasForeignKey(pm => pm.PartId);

            modelBuilder.Entity<PartMovement>()
                .HasOne(pm => pm.Warehouse)
                .WithMany()
                .HasForeignKey(pm => pm.WarehouseId);

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.CarBrandModel)
                .WithMany()
                .HasForeignKey(cp => cp.CarModelId);

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.PartBrandModel)
                .WithMany()
                .HasForeignKey(cp => cp.PartModelId);
        }
    }
}
