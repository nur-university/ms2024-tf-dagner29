using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Models;
namespace Delivery.Applications.UsesCases.Deliveries
{
    public class GetDeliveryPersonByIdQuery : IRequest<DeliveryPersonDto>
    {
        public Guid Id { get; set; }
    }
}
