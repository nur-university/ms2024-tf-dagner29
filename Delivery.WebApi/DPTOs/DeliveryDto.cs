namespace Delivery.WebApi.DPTOs
{
    public class DeliveryDto
    {
        //public Guid Id { get; set; }
        //public string Status { get; set; }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public List<string> RouteStops { get; set; }
        public List<Guid> PackageIds { get; set; }
    }

}
