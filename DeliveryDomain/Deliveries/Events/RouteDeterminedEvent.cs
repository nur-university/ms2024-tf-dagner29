using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Deliveries.Events
{
 //   public record RouteDeterminedEvent(Guid DeliveryId) : DomainEvent;
    public record RouteDeterminedEvent(Guid DeliveryId, DateTime Timestamp) : DomainEvent;

}
