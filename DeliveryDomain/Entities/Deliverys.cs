using Delivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class Deliveryx
    {
        public Guid Id { get; private set; }
        public string Status { get; private set; }
        public List<Package> Packages { get; private set; }
        public DeliveryRoute Route { get; private set; }

        public Deliveryx(Guid id, string status, DeliveryRoute route)
        {
            Id = id;
            Status = status;
            Route = route;
            Packages = new List<Package>();
        }

        public void AddPackage(Package package)
        {
            Packages.Add(package);
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }
    }
}
