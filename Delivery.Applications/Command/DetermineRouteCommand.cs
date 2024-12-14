using Delivery.Domain.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.Command
{
     

    public record DetermineRouteCommand(Guid DeliveryId, DeliveryRoute Route) : IRequest;

}
