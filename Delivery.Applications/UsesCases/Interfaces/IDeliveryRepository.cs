
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.Models;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;


namespace Delivery.Applications.UsesCases.Interfaces
{
    public interface IDeliveryRepository //: IRepository<Deliveryx>
    {

        Task<Guid> CreateDeliveryAsync(Deliveryx delivery);
        Task<Deliveryx> GetDeliveryByIdAsync(Guid id);
        Task<List<Deliveryx>> GetAllDeliveriesAsync();
        Task UpdateDeliveryStatusAsync(Guid id, string status);
        Task AssignDeliveryToPersonAsync(Guid deliveryId, Guid personId);
        Task AddPackageToDeliveryAsync(Guid deliveryId, Guid packageId);
        Task<List<Package>> GetPackagesByDeliveryIdAsync(Guid deliveryId);

    }
}
