using Delivery.Applications.Command;
using Delivery.Applications.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.Handler
{
    public  class DetermineRouteHandler
    {

        private readonly IDeliveryRepository _repository;

        public DetermineRouteHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DetermineRouteCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _repository.GetByIdAsync(request.DeliveryId);
            //var delivery = await _repository.GetByIdAsync(request.DeliveryId, cancellationToken);

            if (delivery == null)
                throw new Exception("Delivery not found");

            delivery.AssignRoute(request.Route);
            //await _repository.SaveAsync(delivery, cancellationToken);
            await _repository.SaveAsync(delivery);
            return Unit.Value;
        }

    }
}
