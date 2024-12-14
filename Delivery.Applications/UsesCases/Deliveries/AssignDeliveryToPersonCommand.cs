//using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Delivery.Domain.Deliveries;
//using Delivery.Domain.Entities;
using Delivery.Domain.Entities;
using Delivery.Domain.ValueObjects;
using Delivery.Domain.Interfaces;

namespace Delivery.Applications.UsesCases.Deliveries
{
    public class AssignDeliveryToPersonCommand
    {
        private readonly IRepository<DeliveryPerson> _deliveryPersonRepository;
        private readonly IRepository<Deliveryx> _deliveryRepository;

        public AssignDeliveryToPersonCommand(IRepository<DeliveryPerson> deliveryPersonRepository, IRepository<Deliverys> deliveryRepository)
        {
            _deliveryPersonRepository = deliveryPersonRepository;
            _deliveryRepository = deliveryRepository;
        }

        public void Execute(Guid personId, Guid deliveryId)
        {
            var person = _deliveryPersonRepository.GetById(personId);
            var delivery = _deliveryRepository.GetById(deliveryId);

            if (person != null && delivery != null)
            {
                person.AssignDelivery(delivery);
                _deliveryPersonRepository.Update(person);
            }
        }
    }
}
