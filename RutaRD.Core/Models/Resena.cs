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

        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        // Campo adicional para mostrar fecha formateada (ej: "Enero 2026")
        [NotMapped]
        public string FechaFormateada { get; set; } = "";

        // Sistema polimórfico
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoriaTipo { get; set; } = ""; // Hotel, Restaurante, TurismoEcologico, TurismoCultural, EventoActividad
    }
}
