using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Applications.UsesCases.Interfaces;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infraestructure.Persistence.Repositories
{
        public class PackageRepository : IPackageRepository
    {
        private readonly ApplicationDbContext _context;

        public PackageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Package> GetByIdAsync(Guid id)
        {
            return await _context.Packages.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Package>> GetAllAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task CreateAsync(Package package)
        {
            await _context.Packages.AddAsync(package);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Package>> GetPackagesByDeliveryIdAsync(Guid deliveryId)
        {
            return await _context.Packages
                .Where(p => EF.Property<Guid?>(p, "DeliveryId") == deliveryId)
                .ToListAsync();
        }

        public async Task AssignToDeliveryAsync(Guid packageId, Guid deliveryId)
        {
            var package = await GetByIdAsync(packageId);
            if (package != null)
            {
                _context.Entry(package).Property("DeliveryId").CurrentValue = deliveryId;
                await _context.SaveChangesAsync();
            }
        }
    }


}
