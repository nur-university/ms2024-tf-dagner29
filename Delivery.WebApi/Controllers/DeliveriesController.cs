using Delivery.WebApi.DPTOs;
using Microsoft.AspNetCore.Mvc;
using MediatR;
 using Delivery.Applications.UsesCases.Deliveries;
using Delivery.Domain.ValueObjects;
using Delivery.Applications.UsesCases.Packages;
using System.Net;
 
namespace Delivery.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DeliveriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDelivery([FromBody] CreateDeliveryRequestDto requestDto)
        {
            var command = new CreateDeliveryCommand
            {
                Status = requestDto.Status,
                //Route = requestDto.Route,
                PackageIds = requestDto.PackageIds
            };

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }
        //public async Task<IActionResult> Create([FromBody] CreateDeliveryCommand command)
        //{
        //    var deliveryId = await _mediator.Send(command);
        //    return CreatedAtAction(nameof(GetById), new { id = deliveryId }, deliveryId);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetDeliveryQuery { DeliveryId = id };
            var delivery = await _mediator.Send(query);
            return Ok(delivery);
        }

        //[HttpPost("{id}/packages")]
        //public async Task<IActionResult> AddPackage(Guid id, [FromBody] AddPackageRequestDto packageDto)
        //{
        //    var command = new AddPackageToDeliveryCommand(id, packageDto.PackageId);
        //    await _mediator.Send(command);
        //    return NoContent();
        //}

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetDeliveryByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateDeliveryStatusRequestDto requestDto)
        {
            var command = new UpdateDeliveryStatusCommand
            {
                DeliveryId = id,
                Status = requestDto.Status
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{id:guid}/assign")]
        public async Task<IActionResult> AssignDelivery(Guid id, [FromBody] AssignDeliveryRequestDto requestDto)
        {
            var command = new AssignDeliveryToPersonCommand
            {
                DeliveryId = id,
                PersonId = requestDto.DeliveryPersonId
            };

            await _mediator.Send(command);
            return NoContent();
        }

    }


}
