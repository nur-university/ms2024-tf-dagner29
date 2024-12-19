using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.Models
{
    public class PackageInfo
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public float Weight { get; set; }
    }
}
