
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;
using Delivery.Domain.ValueObjects;
using Delivery.Domain.Interfaces;
using MediatR;
using Delivery.Applications.Models;

namespace Delivery.Applications.UsesCases.Deliveries
{
    public class CreateDeliveryCommand : IRequest<Guid>
    {

        public string Status { get; set; }
        public DeliveryRoute Route { get; set; }
        public List<Guid> PackageIds { get; set; }

         
    }
}
