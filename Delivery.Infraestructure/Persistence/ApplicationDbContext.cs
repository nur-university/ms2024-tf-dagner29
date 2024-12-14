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
        public DbSet<Deliveryx> Deliveries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configurations go here.
        }
    }
}
