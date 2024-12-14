using Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Delivery.Domain.Interfaces;
namespace Delivery.Infraestructure.Persistence.Repositories
{
    public class DeliveryPersonRepository : IRepository<DeliveryPerson>
    {
        private readonly ApplicationDbContext _context;

        public DeliveryPersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(DeliveryPerson entity)
        {
            _context.DeliveryPersons.Add(entity);
            _context.SaveChanges();
        }

        public DeliveryPerson GetById(Guid id)
        {
            return _context.DeliveryPersons.FirstOrDefault(dp => dp.Id == id);
        }

        public void Remove(Guid id)
        {
            var person = GetById(id);
            if (person != null)
            {
                _context.DeliveryPersons.Remove(person);
                _context.SaveChanges();
            }
        }

        public void Update(DeliveryPerson entity)
        {
            _context.DeliveryPersons.Update(entity);
            _context.SaveChanges();
        }
    }
}
