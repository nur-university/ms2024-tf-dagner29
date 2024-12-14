using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Deliveries;
using Delivery.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;
using Delivery.Infraestructure.StoreModel;

using Delivery.Domain.Addres;
using Delivery.Domain.Paquetes;


namespace Delivery.Infraestructure.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DeliveryContext _context;

        public DeliveryRepository(DeliveryContext context)
        {
            _context = context;
        }

        public async Task<Deliverys> GetByIdAsync(Guid id)
        {
            return await _context.Deliveries
                .Include(d => d.Packages)
                .ThenInclude(p => p.Address)
                .Include(d => d.Route)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Deliverys>> GetAllPendingAsync()
        {
            return await _context.Deliveries
                .Where(d => d.Status == "Pending")
                .ToListAsync();
        }

        public async Task SaveAsync(Deliverys delivery)
        {
            _context.Update(delivery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync();
            }
        }

    }
}
