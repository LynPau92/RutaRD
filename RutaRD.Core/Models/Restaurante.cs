using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutaRD.Core.Models
{
    [Table("Restaurantes")]
    public class Restaurante
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

        public double Estrellas { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; } = "";

        [MaxLength(300)]
        public string? SitioWeb { get; set; } = "";

        [MaxLength(10)]
        public string? RangoPrecios { get; set; } = ""; // $, $$, $$$

        public bool OpcionVegetariana { get; set; } = false;

        public bool OpcionVegana { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación
        public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
    }
}
