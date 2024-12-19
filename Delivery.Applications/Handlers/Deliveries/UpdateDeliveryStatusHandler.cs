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

    public class UpdateDeliveryStatusHandler : IRequestHandler<UpdateDeliveryStatusCommand>
    {
        private readonly IDeliveryRepository _repository;

        public UpdateDeliveryStatusHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDeliveryStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateDeliveryStatusAsync(request.DeliveryId, request.Status);
            return Unit.Value;
        }

        Task IRequestHandler<UpdateDeliveryStatusCommand>.Handle(UpdateDeliveryStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }


    //public class UpdateDeliveryStatusHandler : IRequestHandler<UpdateDeliveryStatusCommand>
    //{
    //    private readonly IDeliveryRepository _repository;

    //    public UpdateDeliveryStatusHandler(IDeliveryRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<Unit> Handle(UpdateDeliveryStatusCommand request, CancellationToken cancellationToken)
    //    {
    //        await _repository.UpdateDeliveryStatusAsync(request.DeliveryId, request.Status);
    //        return Unit.Value;
    //    }

    //}

}
