using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutaRD.Core.Models
{
    [Table("EventosActividades")]
    public class EventosActividades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = "";

        public string? Descripcion { get; set; }

        [MaxLength(300)]
        public string? Imagen { get; set; } = "";

        [MaxLength(200)]
        public string? Ubicacion { get; set; } = "";

        [MaxLength(500)]
        public string? GoogleMapsUrl { get; set; } = "";

        [MaxLength(300)]
        public string? SitioWeb { get; set; } = "";

        [MaxLength(50)]
        public string? Tipo { get; set; } = ""; // Actividad, Festival

        [MaxLength(100)]
        public string? Fecha { get; set; } = "";

        [MaxLength(100)]
        public string? Horario { get; set; } = "";

        [MaxLength(50)]
        public string? PrecioEntrada { get; set; } = "";

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación
        public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
    }
}
