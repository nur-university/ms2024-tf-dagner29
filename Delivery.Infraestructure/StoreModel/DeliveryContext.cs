using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Deliveries;
using Delivery.Domain.Paquetes;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infraestructure.StoreModel
{
    public  class DeliveryContext : DbContext
    {
        public DbSet<Deliverys> Deliveries { get; set; }
        public DbSet<Paquete> Packages { get; set; }

        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deliverys>()
                .HasMany(d => d.Packages)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paquete>()
                .OwnsOne(p => p.Address);
            modelBuilder.Entity<Deliverys>().OwnsOne(d => d.Route);
        }

    }
}
