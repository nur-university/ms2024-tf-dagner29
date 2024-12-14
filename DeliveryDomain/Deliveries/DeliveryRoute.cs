using Delivery.Domain.Addres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Deliveries
{
    public  class DeliveryRoute
    {
        public List<Address> Stops { get; private set; }
        public string OptimalPath { get; private set; }

        public DeliveryRoute(List<Address> stops, string optimalPath)
        {
            Stops = stops ?? throw new ArgumentNullException(nameof(stops));
            OptimalPath = optimalPath ?? throw new ArgumentNullException(nameof(optimalPath));
        }
    }
}
