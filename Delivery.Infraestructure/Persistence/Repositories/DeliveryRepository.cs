using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;
namespace Delivery.Infraestructure.Persistence.Repositories
{
    public class DeliveryRepository : IRepository<Deliveryx>
    {
        private readonly ApplicationDbContext _context;

        public DeliveryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Deliveryx entity)
        {
            _context.Deliveries.Add(entity);
            _context.SaveChanges();
        }

        public Deliveryx GetById(Guid id)
        {
            return _context.Deliveries.FirstOrDefault(d => d.Id == id);
        }

        public void Remove(Guid id)
        {
            var delivery = GetById(id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                _context.SaveChanges();
            }
        }

        public void Update(Deliveryx entity)
        {
            _context.Deliveries.Update(entity);
            _context.SaveChanges();
        }
    }
}
