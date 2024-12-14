using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class DeliveryPerson
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Deliveryx> ActiveDeliveries { get; private set; }

        public DeliveryPerson(Guid id, string name)
        {
            Id = id;
            Name = name;
            ActiveDeliveries = new List<Deliveryx>();
        }

        public void AssignDelivery(Deliveryx delivery)
        {
            ActiveDeliveries.Add(delivery);
        }
    }
}
