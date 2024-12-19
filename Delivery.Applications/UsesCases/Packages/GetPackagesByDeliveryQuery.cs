//using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Models;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;
using MediatR;

namespace Delivery.Applications.UsesCases.Packages
{

    public class GetPackagesByDeliveryQuery : IRequest<List<PackageInfo>>
    {
        public Guid DeliveryId { get; set; }
    }
    //public class GetPackagesByDeliveryQuery
    //{
    //    private readonly IRepository<Deliveryx> _deliveryRepository;

    //    public GetPackagesByDeliveryQuery(IRepository<Deliveryx> deliveryRepository)
    //    {
    //        _deliveryRepository = deliveryRepository;
    //    }

    //    public List<Package> Execute(Guid deliveryId)
    //    {
    //        var delivery = _deliveryRepository.GetById(deliveryId);
    //        return delivery?.Packages ?? new List<Package>();
    //    }
    //}
}
