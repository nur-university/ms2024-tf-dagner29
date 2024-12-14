namespace Delivery.WebApi.DPTOs
{
    public class CreateDeliveryRequestDto
    {
        public string Status { get; set; }
        public Guid DeliveryPersonId { get; set; }
    }
}
