//using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;
//using Delivery.Domain.ValueObjects;
using Delivery.Domain.Interfaces;

namespace Delivery.Applications.UsesCases.Packages
{
    public class AddPackageToDeliveryCommand
    {
        private readonly IRepository<Deliveryx> _deliveryRepository;
        private readonly IRepository<Package> _packageRepository;

        public AddPackageToDeliveryCommand(IRepository<Deliveryx> deliveryRepository, IRepository<Package> packageRepository)
        {
            _deliveryRepository = deliveryRepository;
            _packageRepository = packageRepository;
        }

        public void Execute(Guid deliveryId, Package package)
        {
            var delivery = _deliveryRepository.GetById(deliveryId);

            if (delivery != null)
            {
                delivery.AddPackage(package);
                _deliveryRepository.Update(delivery);
                _packageRepository.Add(package);
            }
        }
    }
}
