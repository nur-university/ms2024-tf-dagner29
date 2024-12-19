using Delivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }

        public DbSet<Deliveryx> Deliveries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deliveryx>().HasKey(d => d.Id);
            modelBuilder.Entity<Package>().HasKey(p => p.Id);
            modelBuilder.Entity<DeliveryPerson>().HasKey(dp => dp.Id);

            modelBuilder.Entity<Deliveryx>()
                .HasMany(d => d.Packages)
                .WithOne()
                .HasForeignKey("DeliveryId");

            modelBuilder.Entity<DeliveryPerson>()
                .HasMany(dp => dp.AssignedDeliveries)
                .WithOne()
                .HasForeignKey("AssignedPersonId"); 

            /*
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeliveryPerson>(entity =>
            {
                entity.HasKey(dp => dp.Id);

                entity.Property(dp => dp.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(dp => dp.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                // Configurar relación uno a muchos con Delivery
                entity.HasMany(dp => dp.AssignedDeliveries)
                      .WithOne(d => d.AssignedPerson)
                      .HasForeignKey(d => d.AssignedPersonId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Deliveryx>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Status)
                    .IsRequired();

                entity.HasOne(d => d.AssignedPerson)
                      .WithMany(dp => dp.AssignedDeliveries)
                      .HasForeignKey(d => d.AssignedPersonId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Package>()
                .OwnsOne(p => p.Address);
            */
        }

    }
}
