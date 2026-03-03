using Frontend.Models;

namespace Frontend.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Imagen { get; set; } = "";
        public string Ubicacion { get; set; } = "";
        public string GoogleMapsUrl { get; set; } = "";
        public double Estrellas { get; set; }
        public string Telefono { get; set; } = "";
        public string SitioWeb { get; set; } = "";
        public string RangoPrecios { get; set; } = "";
        public bool OpcionVegetariana { get; set; } = false;
        public bool OpcionVegana { get; set; } = false;
        public List<Resena> Resenas { get; set; } = new();
    }
}