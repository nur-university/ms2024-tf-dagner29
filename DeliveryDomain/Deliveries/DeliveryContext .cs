using Delivery.Domain.Addres;
using Delivery.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Deliveries
{
    public class DeliveryContext : DbContext
    {

        public DbSet<Deliverys> Deliveries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }

        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>()
                .HasMany(d => d.Packages)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Package>()
                .OwnsOne(p => p.Address);

            modelBuilder.Entity<Delivery>()
                .OwnsOne(d => d.Route);
        }
    }
}
