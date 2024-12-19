using Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Delivery.Applications.UsesCases.Interfaces;
 
namespace Delivery.Infraestructure.Persistence.Repositories
{

    public class DeliveryPersonRepository : IDeliveryPersonRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DeliveryPersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeliveryPerson> GetByIdAsync(Guid id)
        {
            return await _dbContext.DeliveryPersons
                .Include(dp => dp.AssignedDeliveries)
                .FirstOrDefaultAsync(dp => dp.Id == id);
        }

     }
    
}
