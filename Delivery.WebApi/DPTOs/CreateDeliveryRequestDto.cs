namespace Delivery.WebApi.DPTOs
{
    public class CreateDeliveryRequestDto
    {
        //public string Status { get; set; }
        //public List<string> RouteStops { get; set; }
        //public List<Guid> PackageIds { get; set; }


        public string Status { get; set; }

        // Lista de paradas de la ruta como parte del DTO
        public List<AddressDto> Stops { get; set; }

        public string OptimalPath { get; set; }

        // Lista de identificadores de paquetes
        public List<Guid> PackageIds { get; set; }


    }


    // Address DTO para representar las paradas de la ruta
    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }

}
