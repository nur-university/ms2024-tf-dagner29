using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }

        public Address(string street, string city, float latitude, float longitude)
        {
            Street = street;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
