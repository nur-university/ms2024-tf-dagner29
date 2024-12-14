namespace Delivery.WebApi.DPTOs
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public float Weight { get; set; }
    }
}
