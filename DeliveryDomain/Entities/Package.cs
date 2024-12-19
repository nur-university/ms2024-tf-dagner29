using Delivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class Package
    {
        public Guid Id { get;  set; }
        public float Weight { get;  set; }
        public Address Address { get;  set; }

        // Relación con Delivery
        public Guid? DeliveryId { get; set; }
        public Deliveryx Delivery { get; private set; }
        public Package(Guid id, float weight, Address address)
        {
            Id = id;
            Weight = weight;
            Address = address;
        }
        public void AssignToDelivery(Deliveryx delivery)
        {
            Delivery = delivery ?? throw new ArgumentNullException(nameof(delivery));
            DeliveryId = delivery.Id;
        }
    }
}
