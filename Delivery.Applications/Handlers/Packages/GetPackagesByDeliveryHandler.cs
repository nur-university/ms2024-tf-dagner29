using Delivery.Applications.Models;
using Delivery.Applications.UsesCases.Interfaces;
using Delivery.Applications.UsesCases.Packages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.Handlers.Packages
{
    /*
    public class GetPackagesByDeliveryHandler : IRequestHandler<AddPackageToDeliveryCommand>// IRequestHandler<GetPackagesByDeliveryQuery, List<PackageInfo>>
    {
        private readonly IDeliveryRepository _repository;

        public GetPackagesByDeliveryHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(AddPackageToDeliveryCommand request, CancellationToken cancellationToken)
        {
            // Llama al método correspondiente en el repositorio
            await _repository.AddPackageToDeliveryAsync(request.DeliveryId, request.Package);
            return Unit.Value;
        }
    }
    */

}
