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
        public string Email { get; private set; }

        public List<Deliveryx> AssignedDeliveries { get; private set; }

        // Constructor requerido por EF Core
        private DeliveryPerson()
        {
            AssignedDeliveries = new List<Deliveryx>();
        }



        public DeliveryPerson(Guid id, string name)
        {
            Id = id;
            Name = name;
            AssignedDeliveries = new List<Deliveryx>();
        }

        public void AssignDelivery(Deliveryx delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException(nameof(delivery));
            AssignedDeliveries.Add(delivery);
        }
        // Método para eliminar una entrega
        public void RemoveDelivery(Deliveryx delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException(nameof(delivery));

            AssignedDeliveries.Remove(delivery);
        }

    }
}
