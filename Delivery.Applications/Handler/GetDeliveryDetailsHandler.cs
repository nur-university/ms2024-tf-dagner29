using Delivery.Applications.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Dpto;
using Delivery.Applications.Abstractions;
namespace Delivery.Applications.Handler
{
    public class GetDeliveryDetailsHandler : IRequestHandler<GetDeliveryDetailsQuery, DeliveryDetailsDto>
    {
        private readonly IStoredModelRepository _storedModelRepository;

        public GetDeliveryDetailsHandler(IStoredModelRepository storedModelRepository)
        {
            _storedModelRepository = storedModelRepository;
        }

        public async Task<DeliveryDetailsDto> Handle(GetDeliveryDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _storedModelRepository.GetDeliveryDetailsAsync(request.DeliveryId, cancellationToken);
        }
    }
}
