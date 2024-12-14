//using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;

namespace Delivery.Applications.UsesCases.Packages
{
    public class GetPackagesByDeliveryQuery
    {
        private readonly IRepository<Deliveryx> _deliveryRepository;

        public GetPackagesByDeliveryQuery(IRepository<Deliveryx> deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public List<Package> Execute(Guid deliveryId)
        {
            var delivery = _deliveryRepository.GetById(deliveryId);
            return delivery?.Packages ?? new List<Package>();
        }
    }
}
