using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.Models
{
    public class DeliveryDto
    {
        //public Guid Id { get; set; }
        //public string Status { get; set; }
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Route { get; set; }
    }


    public class PackageDto
    {
        //public Guid Id { get; set; }
        //public string Status { get; set; }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public List<string> RouteStops { get; set; }
        public List<Guid> PackageIds { get; set; }
    }

}
