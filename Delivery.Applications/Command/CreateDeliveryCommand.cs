using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Paquetes;

namespace Delivery.Applications.Command
{
    public record CreateDeliveryCommand(List<Paquete> Packages) : IRequest<Guid>;

}
