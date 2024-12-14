//using Delivery.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;

//using Delivery.Domain.Deliveries;
//using Delivery.Domain.Interfaces;
namespace Delivery.Applications.UsesCases.Interfaces
{
    public interface IDeliveryRepository : IRepository<Deliveryx>
    {
        List<Deliveryx> GetByStatus(string status);
    }
}
