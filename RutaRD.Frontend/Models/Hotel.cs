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

        // Propiedades de navegación del backend
        public List<HotelServicio>? HotelServicios { get; set; }
        public List<Resena>? ResenasBackend { get; set; }

        // Propiedades calculadas para el frontend
        public List<string> Servicios => HotelServicios?.Select(hs => hs.Servicio).ToList() ?? new List<string>();
        public List<Resena> Resenas => ResenasBackend ?? new List<Resena>();
    }

    public class HotelServicio
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Servicio { get; set; } = "";
    }
}