

using Delivery.Domain.Abstractions;
using Delivery.Domain.Addres;
using Delivery.Domain.Deliveries.Events;
using Delivery.Domain.Paquetes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Delivery.Domain.Deliveries
{
    public class Deliverys: AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Status { get; private set; }
        public List<Paquete> Packages { get; private set; }
        public List<Address> Address { get; private set; }
        //public DeliveryRoute Route { get; private set; }

       // private readonly List<DomainEvent> _domainEvents = new();
        private new readonly List<DomainEvent> _domainEvents = [];


        public Deliverys(Guid id, string status,List<Address> addresses)
        {
            Id = id;
            //Address = address ?? throw new ArgumentNullException(nameof(address));
            //Packages = new List<Paquete>();
            Status = status;

            Status = "Pending";
            addresses = addresses ?? new();

        }

        public void AddPackage(Paquete package)
        {
            if (package == null)
                throw new ArgumentNullException(nameof(package));

            Packages.Add(package);
        }

        public void AssignRoute(DeliveryRoute route)
        {
            //Address = stops;
            Status = "Route Assigned";
            AddDomainEvent(new RouteDeterminedEvent(Id, DateTime.UtcNow));
        }

        public void MarkAsDelivered()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Only pending deliveries can be marked as delivered.");

            Status = "Delivered";

        }
        //public void DetermineRoute(DeliveryRoute route)
        //{
        //    Route = route;
        //    Status = "RouteDetermined";

        //    // Disparar el evento
        //    DomainEvents.Raise(new RouteDeterminedEvent(Id, DateTime.UtcNow));
        //}



        //public void SetRoute(DeliveryRoute route)
        //{
        //    Route = route;
        //    AddDomainEvent(new RouteDeterminedEvent(Id, DateTime.UtcNow));

        //}

    }
}
