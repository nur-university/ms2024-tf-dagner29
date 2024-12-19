using Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.UsesCases.Interfaces
{
    public interface IDeliveryPersonRepository
    {
        Task<DeliveryPerson> GetByIdAsync(Guid id);
    }
}
