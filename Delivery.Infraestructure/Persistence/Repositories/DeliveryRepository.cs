using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Models;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;
using Delivery.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Delivery.Applications.UsesCases.Interfaces;


namespace Delivery.Infraestructure.Persistence.Repositories
{

    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateDeliveryAsync(Deliveryx delivery)
        {
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
            return delivery.Id;
        }

        public async Task<Deliveryx> GetDeliveryByIdAsync(Guid id)
        {
            return await _context.Deliveries
                .Include(d => d.Packages)
                .Include(d => d.AssignedPerson)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Deliveryx>> GetAllDeliveriesAsync()
        {
            return await _context.Deliveries
                .Include(d => d.Packages)
                .Include(d => d.AssignedPerson)
                .ToListAsync();
        }

        public async Task UpdateDeliveryStatusAsync(Guid id, string status)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery != null)
            {

                string status1 = status;
                delivery.Status = status;
                _context.Deliveries.Update(delivery);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AssignDeliveryToPersonAsync(Guid deliveryId, Guid personId)
        {
            var delivery = await _context.Deliveries.FindAsync(deliveryId);
            var person = await _context.DeliveryPersons.FindAsync(personId);
            if (delivery != null && person != null)
            {
                delivery.AssignedPerson = person;
                _context.Deliveries.Update(delivery);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddPackageToDeliveryAsync(Guid deliveryId, Guid packageId)
        {
            var delivery = await _context.Deliveries.FindAsync(deliveryId);
            var package = await _context.Packages.FindAsync(packageId);
            if (delivery != null && package != null)
            {
                delivery.Packages.Add(package);
                package.DeliveryId = deliveryId;
                _context.Packages.Update(package);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Package>> GetPackagesByDeliveryIdAsync(Guid deliveryId)
        {
            return await _context.Packages
                .Where(p => p.DeliveryId == deliveryId)
                .ToListAsync();
        }
    }



}
