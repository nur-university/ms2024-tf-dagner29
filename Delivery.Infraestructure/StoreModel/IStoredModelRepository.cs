using Delivery.Applications.Dpto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infraestructure.StoreModel
{
    public interface IStoredModelRepository
    {
        Task<DeliveryDetailsDto> GetDeliveryDetailsAsync(Guid deliveryId, CancellationToken cancellationToken);
    }
}
