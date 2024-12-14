using Delivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class Package
    {
        public Guid Id { get; private set; }
        public float Weight { get; private set; }
        public Address Address { get; private set; }

        public Package(Guid id, float weight, Address address)
        {
            Id = id;
            Weight = weight;
            Address = address;
        }
    }
}
