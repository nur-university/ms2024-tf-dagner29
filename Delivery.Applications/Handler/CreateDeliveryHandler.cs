using Delivery.Applications.Command;
using Delivery.Applications.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Deliveries;
namespace Delivery.Applications.Handler
{
    public class CreateDeliveryHandler: IRequestHandler<CreateDeliveryCommand, Guid>
    {
        private readonly IDeliveryRepository _repository;

        public CreateDeliveryHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = new Deliverys(Guid.NewGuid());
            delivery.Packages.AddRange(request.Packages);
           // await _repository.SaveAsync(delivery, cancellationToken);
            await _repository.SaveAsync(delivery);

            return delivery.Id;
        }
    }
}
