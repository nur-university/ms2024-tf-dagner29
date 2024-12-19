using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.Models
{
    public class CreateDeliveryRequestDto
    {
        public Guid AssignedPersonId { get; set; }
        public List<AddPackageRequestDto> Packages { get; set; }
        public List<string> RouteStops { get; set; }
    }
}
