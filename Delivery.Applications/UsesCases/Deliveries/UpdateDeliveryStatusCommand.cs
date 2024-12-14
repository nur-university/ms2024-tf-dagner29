//using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Delivery.Domain./*Deliveries*/;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;

namespace Delivery.Applications.UsesCases.Deliveries
{
    public class UpdateDeliveryStatusCommand
    {
        private readonly IRepository<Deliveryx> _deliveryRepository;

        public UpdateDeliveryStatusCommand(IRepository<Deliveryx> deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public void Execute(Guid id, string newStatus)
        {
            var delivery = _deliveryRepository.GetById(id);
            delivery?.UpdateStatus(newStatus);
            if (delivery != null)
            {
                _deliveryRepository.Update(delivery);
            }
        }
    }
}
