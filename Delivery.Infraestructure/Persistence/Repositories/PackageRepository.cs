using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Delivery.Domain.Entities;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;

namespace Delivery.Infraestructure.Persistence.Repositories
{
    public class PackageRepository : IRepository<Package>
    {
        private readonly ApplicationDbContext _context;

        public PackageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Package entity)
        {
            _context.Packages.Add(entity);
            _context.SaveChanges();
        }

        public Package GetById(Guid id)
        {
            return _context.Packages.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(Guid id)
        {
            var package = GetById(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
                _context.SaveChanges();
            }
        }

        public void Update(Package entity)
        {
            _context.Packages.Update(entity);
            _context.SaveChanges();
        }
    }
}
