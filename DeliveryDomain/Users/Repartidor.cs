using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Users
{
    public  class Repartidor : AggregateRoot
    {

        public string FullName { get; private set; }
        internal Repartidor(Guid id, string fullname) : base(id)
        {
            FullName = fullname;
        }

        public static Repartidor Create(Guid id, string fullname)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id cannot be empty", nameof(id));
            }
            if (string.IsNullOrEmpty(fullname))
            {
                throw new ArgumentException("fullname cannot be null or empty", nameof(fullname));
            }
            return new Repartidor(id, fullname);
        }

        public void Update(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                throw new ArgumentException("fullname cannot be null or empty", nameof(fullname));
            }
            FullName = fullname;
        }

        //Need for EF Core
        private Repartidor() : base() { }

    }
}
