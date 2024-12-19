using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Event
{
    public class DeliveryCreatedEvent
    {
        public Guid DeliveryId { get; }
        public DateTime CreatedAt { get; }

        public DeliveryCreatedEvent(Guid deliveryId)
        {
            DeliveryId = deliveryId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
