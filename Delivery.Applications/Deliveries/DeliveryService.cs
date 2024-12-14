using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Deliveries;
namespace Delivery.Applications.Deliveries
{
    public class DeliveryService
    {
        private readonly IDeliveryRepository _repository;

        public DeliveryService(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task AssignRouteAsync(Guid deliveryId, DeliveryRoute route)
        {
            var delivery = await _repository.GetByIdAsync(deliveryId);
            if (delivery == null) throw new Exception("Delivery not found.");

            delivery.AssignRoute(route);
            await _repository.SaveAsync(delivery);
        }

        public async Task<IEnumerable<Deliverys>> GetPendingDeliveriesAsync()
        {
            return await _repository.GetAllPendingAsync();
        }
    }
}
