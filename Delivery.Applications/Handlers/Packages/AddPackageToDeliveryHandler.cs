using Delivery.Applications.UsesCases.Interfaces;
using Delivery.Applications.UsesCases.Packages;
 using Delivery.Domain.ValueObjects;
using Delivery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Delivery.Applications.Handlers.Packages
{

    public class AddPackageToDeliveryHandler : IRequestHandler<AddPackageToDeliveryCommand>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IPackageRepository _packageRepository;

        public AddPackageToDeliveryHandler(IDeliveryRepository deliveryRepository, IPackageRepository packageRepository)
        {
            _deliveryRepository = deliveryRepository;
            _packageRepository = packageRepository;
        }

        public async Task<Unit> Handle(AddPackageToDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);
            var package = await _packageRepository.GetByIdAsync(request.PackageId);

            delivery.AddPackage(package);
            await _deliveryRepository.UpdateAsync(delivery);

            return Unit.Value;
        }
    }
    /*
    public class AddPackageToDeliveryHandler : IRequestHandler<AddPackageToDeliveryCommand>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IPackageRepository _packageRepository;

        public AddPackageToDeliveryHandler(IDeliveryRepository deliveryRepository, IPackageRepository packageRepository)
        {
            _deliveryRepository = deliveryRepository;
            _packageRepository = packageRepository;
        }

        public async Task<Unit> Handle(AddPackageToDeliveryCommand request, CancellationToken cancellationToken)
        {
            // Verificar si la entrega existe
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryId);
            if (delivery == null)
            {
                throw new ArgumentException($"Delivery with ID {request.DeliveryId} does not exist.");
            }

            // Verificar si el paquete existe
            var package = await _packageRepository.GetByIdAsync(request.PackageId);
            if (package == null)
            {
                throw new ArgumentException($"Package with ID {request.PackageId} does not exist.");
            }

            // Asignar el paquete a la entrega
            delivery.AddPackage(package);

            // Persistir cambios
            await _deliveryRepository.UpdateAsync(delivery);

            return Unit.Value;
        }
    }
   */
}
