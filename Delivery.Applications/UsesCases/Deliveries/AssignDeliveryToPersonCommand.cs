using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;
using Delivery.Domain.ValueObjects;
using Delivery.Domain.Interfaces;
using MediatR;

namespace Delivery.Applications.UsesCases.Deliveries
{

    public class AssignDeliveryToPersonCommand : IRequest
    {
        public Guid DeliveryId { get; set; }
        public Guid PersonId { get; set; }
    }


}
