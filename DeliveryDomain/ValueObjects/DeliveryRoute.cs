//using Delivery.Domain.Addres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.ValueObjects
{
    public class DeliveryRoute
    {
        public IReadOnlyList<Address> Stops { get; private set; } // Cambiado a solo lectura
        public string OptimalPath { get; private set; }
        public DeliveryRoute(List<Address> stops, string optimalPath)
        {
            Stops = stops;
            OptimalPath = optimalPath;
        }

        //public List<Address> Stops { get; private set; }
        //public string OptimalPath { get; private set; }

        //public DeliveryRoute(List<Address> stops, string optimalPath)
        //{
        //    Stops = stops;
        //    OptimalPath = optimalPath;
        //}

        //public DeliveryRoute(List<Address> stops, string optimalPath)
        //{
        //    // Validaciones de argumentos
        //    if (stops == null || !stops.Any())
        //        throw new ArgumentException("DeliveryRoute must have at least one stop.", nameof(stops));

        //    if (string.IsNullOrWhiteSpace(optimalPath))
        //        throw new ArgumentException("OptimalPath cannot be null or empty.", nameof(optimalPath));

        //    Stops = new List<Address>(stops);
        //    OptimalPath = optimalPath;
        //}

        //// Método para actualizar las paradas
        //public void UpdateStops(List<Address> stops)
        //{
        //    if (stops == null || !stops.Any())
        //        throw new ArgumentException("DeliveryRoute must have at least one stop.", nameof(stops));

        //    Stops = new List<Address>(stops);
        //}

        //// Método para actualizar el camino óptimo
        //public void UpdateOptimalPath(string optimalPath)
        //{
        //    if (string.IsNullOrWhiteSpace(optimalPath))
        //        throw new ArgumentException("OptimalPath cannot be null or empty.", nameof(optimalPath));

        //    OptimalPath = optimalPath;
        //}

        //// Representación de la ruta en string
        //public override string ToString()
        //{
        //    var stops = string.Join(" -> ", Stops.Select(s => $"{s.Street}, {s.City}"));
        //    return $"Route: {stops}. Optimal Path: {OptimalPath}";
        //}




    }
}
