using Delivery.Domain.Event;
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
        public string Status { get;  set; }
        public List<Package> Packages { get; private set; }
        public DeliveryRoute Route { get; private set; }
        //public Guid DeliveryPersonId { get; private set; }

     

        // Relación con DeliveryPerson
        public Guid? AssignedPersonId { get;  set; }
        public DeliveryPerson AssignedPerson { get; set; }


       // private Deliveryx() { }

 
        public event Action<Deliveryx> OnDeliveryCreated;

        public Deliveryx(Guid id, string status, DeliveryRoute route)
        {
            Id = id;
            Status = status;
            Route = route;
            Packages = new List<Package>();
            RaiseDeliveryCreated();
        }

        public Deliveryx(string status, DeliveryRoute route)
        {
            Id = Guid.NewGuid();
            Status = status;
            Route = route;
            Packages = new List<Package>();
        }

        public void AddPackage(Package package)
        {
            Packages.Add(package);
        }
        // Assign delivery person
        //public void AssignDeliveryPerson(Guid deliveryPersonId)
        //{
        //    DeliveryPersonId = deliveryPersonId;
        //}
        public void AssignPerson(DeliveryPerson person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            AssignedPerson = person;
            AssignedPersonId = person.Id;
        }
        public void UpdateStatus(string status)
        {
            Status = status;
        }

        public void UnassignPerson()
        {
            AssignedPerson = null;
            AssignedPersonId = null;
        }
        //Raise domain event when delivery is created
        private void RaiseDeliveryCreated()
        {
            OnDeliveryCreated?.Invoke(this);
        }


    }
}
