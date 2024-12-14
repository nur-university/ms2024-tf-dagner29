using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Dpto;
namespace Delivery.Applications.Queries
{

    public record GetDeliveryDetailsQuery(Guid DeliveryId) : IRequest<DeliveryDetailsDto>;

}
