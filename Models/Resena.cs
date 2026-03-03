namespace Frontend.Models
{
    public class Resena
    {
        public int Id { get; set; }
        public string NombreVisitante { get; set; } = "";
        public string Comentario { get; set; } = "";
        public double Calificacion { get; set; }
        public string Fecha { get; set; } = "";
    }
}