using Delivery.Applications.UsesCases.Deliveries;
using Delivery.WebApi.DPTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.WebApi.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]
        public class DeliveryPersonsController : ControllerBase
        {
            private readonly IMediator _mediator;

            public DeliveryPersonsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(Guid id)
            {
                var query = new GetDeliveryPersonByIdQuery { Id = id };
                var deliveryPerson = await _mediator.Send(query);
                return Ok(deliveryPerson);
            }
        }

       
    
}
