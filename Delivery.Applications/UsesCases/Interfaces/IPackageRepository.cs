using Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.UsesCases.Interfaces
{
    public interface IPackageRepository
    {
        Task<Package> GetByIdAsync(Guid id);
        Task<List<Package>> GetAllAsync();
        Task CreateAsync(Package package);
        Task<List<Package>> GetPackagesByDeliveryIdAsync(Guid deliveryId);
        Task AssignToDeliveryAsync(Guid packageId, Guid deliveryId);
    }
}
