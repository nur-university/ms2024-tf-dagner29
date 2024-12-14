using Microsoft.AspNetCore.Mvc;
using Delivery.Applications.UsesCases.Deliveries;
using Delivery.Applications.UsesCases.Packages;
using Delivery.WebApi.DPTOs;
namespace Delivery.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly AddPackageToDeliveryCommand _addPackageCommand;
        private readonly GetPackagesByDeliveryQuery _getPackagesQuery;

        public PackagesController(
            AddPackageToDeliveryCommand addPackageCommand,
            GetPackagesByDeliveryQuery getPackagesQuery)
        {
            _addPackageCommand = addPackageCommand;
            _getPackagesQuery = getPackagesQuery;
        }

        [HttpPost]
        public IActionResult AddPackage(PackageDto package)
        {
            _addPackageCommand.Execute(package);
            return Ok();
        }

        [HttpGet("delivery/{deliveryId}")]
        public IActionResult GetPackages(Guid deliveryId)
        {
            var packages = _getPackagesQuery.Execute(deliveryId);
            return Ok(packages);
        }
    }
}
