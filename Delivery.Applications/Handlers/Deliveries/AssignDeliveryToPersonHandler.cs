using Delivery.Applications.UsesCases.Deliveries;
using Delivery.Applications.UsesCases.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Applications.Handlers.Deliveries
{

    public class AssignDeliveryToPersonHandler : IRequestHandler<AssignDeliveryToPersonCommand>
    {
        private readonly IDeliveryRepository _repository;

        public AssignDeliveryToPersonHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AssignDeliveryToPersonCommand request, CancellationToken cancellationToken)
        {
            await _repository.AssignDeliveryToPersonAsync(request.DeliveryId, request.PersonId);
            return Unit.Value;
        }

        Task IRequestHandler<AssignDeliveryToPersonCommand>.Handle(AssignDeliveryToPersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
    //public class AssignDeliveryToPersonHandler : IRequestHandler<AssignDeliveryToPersonCommand>
    //{
    //    private readonly IDeliveryRepository _repository;

    //    public AssignDeliveryToPersonHandler(IDeliveryRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<Unit> Handle(AssignDeliveryToPersonCommand request, CancellationToken cancellationToken)
    //    {
    //        await _repository.AssignDeliveryToPersonAsync(request.DeliveryId, request.PersonId);
    //        return Unit.Value;
    //    }
    //}
}
