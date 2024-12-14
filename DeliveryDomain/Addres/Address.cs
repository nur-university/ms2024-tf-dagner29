using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Addres
{
    public class Address
    {

        public string Street { get; private set; }
        public string City { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Address(string street, string city, double latitude, double longitude)
        {
            Street = street;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, Latitude, Longitude);
        }
    }
}
