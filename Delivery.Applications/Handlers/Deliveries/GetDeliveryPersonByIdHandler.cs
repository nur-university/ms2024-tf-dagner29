using Delivery.Applications.Models;
using Delivery.Applications.UsesCases.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.UsesCases.Interfaces;
namespace Delivery.Applications.Handlers.Deliveries
{

    public class GetDeliveryPersonByIdHandler : IRequestHandler<GetDeliveryPersonByIdQuery, DeliveryPersonDto>
    {
        private readonly IDeliveryPersonRepository _repository;

        public GetDeliveryPersonByIdHandler(IDeliveryPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeliveryPersonDto> Handle(GetDeliveryPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var deliveryPerson = await _repository.GetByIdAsync(request.Id);

            if (deliveryPerson == null)
                return null;

            return new DeliveryPersonDto
            {
                Id = deliveryPerson.Id,
                Name = deliveryPerson.Name,
                Email = deliveryPerson.Email,
                AssignedDeliveries = deliveryPerson.AssignedDeliveries.Select(d => new DeliveryDto
                {
                    Id = d.Id,
                    Status = d.Status,
                    Route = d.Route.ToString()
                }).ToList()
            };
        }
    }
}
