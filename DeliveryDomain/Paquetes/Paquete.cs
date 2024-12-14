using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Addres;

namespace Delivery.Domain.Paquetes
{
    public class Paquete
    {

        public Guid Id { get; private set; }
        public float Weight { get; private set; }
        public Address Address { get; private set; }

        public Paquete(Guid id, float weight, Address address)
        {
            Id = id;
            Weight = weight;
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }



    }
}
