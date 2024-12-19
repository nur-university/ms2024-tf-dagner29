using Delivery.Applications.UsesCases.Deliveries;
using Delivery.Applications.UsesCases.Interfaces;
using Delivery.Domain.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;

//using Delivery.Applications.UsesCases.Deliveries;

namespace Delivery.Applications.Handlers.Deliveries
{
     public class CreateDeliveryHandler : IRequestHandler<CreateDeliveryCommand, Guid>
    {

        private readonly IDeliveryRepository _repository;

        public CreateDeliveryHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }

   
        public async Task<Guid> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            // Crear la nueva entrega (Delivery)
            var delivery = new Deliveryx(request.Status, request.Route);

            // Registrar la entrega en la base de datos
            await _repository.CreateDeliveryAsync(delivery);

            // Devolver el identificador de la nueva entrega
            return delivery.Id;
        }






    }
}
