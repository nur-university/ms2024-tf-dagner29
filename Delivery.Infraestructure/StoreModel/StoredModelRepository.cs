using Delivery.Applications.Dpto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Abstractions;
using Microsoft.EntityFrameworkCore;
using Delivery.Infraestructure.StoreModel;
namespace Delivery.Infraestructure.StoreModel
{
    internal class StoredModelRepository : IStoredModelRepository
    {
        private readonly ApplicationDbContext _context;

        public StoredModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeliveryDetailsDto> GetDeliveryDetailsAsync(Guid deliveryId, CancellationToken cancellationToken)
        {
            return await _context.DeliveryDetails
                .Where(d => d.Id == deliveryId)
                .Select(d => new DeliveryDetailsDto
                {
                    Id = d.Id,
                    Status = d.Status,
                    Route = d.Route,
                    Packages = d.Packages
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
