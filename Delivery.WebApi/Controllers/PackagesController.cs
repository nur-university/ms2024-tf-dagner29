using Microsoft.AspNetCore.Mvc;
using Delivery.Applications.UsesCases.Deliveries;
using Delivery.Applications.UsesCases.Packages;
using Delivery.WebApi.DPTOs;
using MediatR;

namespace Delivery.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PackagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddPackageToDelivery([FromBody] AddPackageRequestDto requestDto, Guid deliveryId)
        {
            var command = new AddPackageToDeliveryCommand(deliveryId, requestDto.Address, requestDto.Weight);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{deliveryId}")]
        public async Task<ActionResult<List<PackageDto>>> GetPackagesByDeliveryId(Guid deliveryId)
        {
            var query = new GetPackagesByDeliveryQuery(deliveryId);
            var packages = await _mediator.Send(query);
            return Ok(packages);
        }
        //private readonly AddPackageToDeliveryCommand _addPackageCommand;
        //private readonly GetPackagesByDeliveryQuery _getPackagesQuery;

        //public PackagesController(
        //    AddPackageToDeliveryCommand addPackageCommand,
        //    GetPackagesByDeliveryQuery getPackagesQuery)
        //{
        //    _addPackageCommand = addPackageCommand;
        //    _getPackagesQuery = getPackagesQuery;
        //}

        //[HttpPost]
        //public IActionResult AddPackage(PackageDto package)
        //{
        //    _addPackageCommand.Execute(package);
        //    return Ok();
        //}

        //[HttpGet("delivery/{deliveryId}")]
        //public IActionResult GetPackages(Guid deliveryId)
        //{
        //    var packages = _getPackagesQuery.Execute(deliveryId);
        //    return Ok(packages);
        //}
    }
}
