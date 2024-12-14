//using Delivery.Domain.Abstractions;
//using Delivery.Domain.Deliveries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;
using Delivery.Domain.ValueObjects;
using Delivery.Domain.Interfaces;

namespace Delivery.Applications.UsesCases.Deliveries
{
    public class CreateDeliveryCommand
    {
        private readonly IRepository<Deliveryx> _deliveryRepository;

        public CreateDeliveryCommand(IRepository<Deliveryx> deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public void Execute(Guid id, string status, DeliveryRoute route)
        {
            var delivery = new Deliveryx(id, status, route);
            _deliveryRepository.Add(delivery);
        }
    }
}
