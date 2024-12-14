using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Remove(Guid id);
    }
}
