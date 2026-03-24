using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutaRD.Core.Models
{
    [Table("Resenas")]
    public class Resena
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreVisitante { get; set; } = "";

        public string? Comentario { get; set; } = "";

        public double Calificacion { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Sistema polimórfico
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoriaTipo { get; set; } = ""; // Hotel, Restaurante, TurismoEcologico, TurismoCultural, EventoActividad
    }
}
