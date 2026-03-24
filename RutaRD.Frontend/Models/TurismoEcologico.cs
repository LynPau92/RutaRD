namespace Frontend.Models
{
    public class TurismoEcologico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Imagen { get; set; } = "";
        public string Ubicacion { get; set; } = "";
        public string GoogleMapsUrl { get; set; } = "";
        public string SitioWeb { get; set; } = "";
        public string TipoLugar { get; set; } = "";
        public string TipoActividad { get; set; } = "";
        public string NivelDificultad { get; set; } = "";
        public string PrecioEntrada { get; set; } = "";
        public string Horario { get; set; } = "";
        public List<Resena> Resenas { get; set; } = new();
    }
}