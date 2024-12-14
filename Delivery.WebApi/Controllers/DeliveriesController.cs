using Delivery.WebApi.DPTOs;
using Microsoft.AspNetCore.Mvc;


using Delivery.Applications.UsesCases.Deliveries;
 

namespace Delivery.WebApi.Controllers
{
    public class DeliveriesController : ControllerBase
    {
        private readonly CreateDeliveryCommand _createDeliveryCommand;
        private readonly UpdateDeliveryStatusCommand _updateDeliveryStatusCommand;
        private readonly AssignDeliveryToPersonCommand _assignDeliveryToPersonCommand;

        public DeliveriesController(
            CreateDeliveryCommand createDeliveryCommand,
            UpdateDeliveryStatusCommand updateDeliveryStatusCommand,
            AssignDeliveryToPersonCommand assignDeliveryToPersonCommand)
        {
            _createDeliveryCommand = createDeliveryCommand;
            _updateDeliveryStatusCommand = updateDeliveryStatusCommand;
            _assignDeliveryToPersonCommand = assignDeliveryToPersonCommand;
        }

        [HttpPost]
        public IActionResult CreateDelivery(CreateDeliveryRequestDto request)
        {
            var deliveryId = _createDeliveryCommand.Execute(request);
            return CreatedAtAction(nameof(GetDeliveryById), new { id = deliveryId }, deliveryId);
        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateStatus(Guid id, [FromBody] string status)
        {
            _updateDeliveryStatusCommand.Execute(id, status);
            return NoContent();
        }

        [HttpPatch("{id}/assign-person")]
        public IActionResult AssignToPerson(Guid id, [FromBody] Guid personId)
        {
            _assignDeliveryToPersonCommand.Execute(id, personId);
            return NoContent();
        }
    }
}
