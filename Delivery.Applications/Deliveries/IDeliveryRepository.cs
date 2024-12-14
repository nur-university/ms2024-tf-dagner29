using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Deliveries;
namespace Delivery.Applications.Deliveries
{
    public  interface IDeliveryRepository
    {
        Task<Deliverys> GetByIdAsync(Guid id);
        Task<IEnumerable<Deliverys>> GetAllPendingAsync();
        Task SaveAsync(Deliverys delivery);
        Task DeleteAsync(Guid id);
    }
}
