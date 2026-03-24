namespace Frontend.Models
{
    public class EventosActividades
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Imagen { get; set; } = "";
        public string Ubicacion { get; set; } = "";
        public string GoogleMapsUrl { get; set; } = "";
        public string SitioWeb { get; set; } = "";
        public string Tipo { get; set; } = "";
        public string Fecha { get; set; } = "";
        public string Horario { get; set; } = "";
        public string PrecioEntrada { get; set; } = "";
        public List<Resena> Resenas { get; set; } = new();
    }
}