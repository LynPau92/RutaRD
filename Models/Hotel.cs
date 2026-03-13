using Frontend.Models;

namespace Frontend.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Imagen { get; set; } = "";
        public string Ubicacion { get; set; } = "";
        public string GoogleMapsUrl { get; set; } = "";
        public double Estrellas { get; set; }
        public decimal PrecioNoche { get; set; }
        public string Telefono { get; set; } = "";
        public string SitioWeb { get; set; } = "";
        public string Tipo { get; set; } = "";
        public List<string> Servicios { get; set; } = new();
        public List<Resena> Resenas { get; set; } = new();
    }
}