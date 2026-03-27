using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutaRD.Core.Models
{
    [Table("HotelServicios")]
    public class HotelServicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Servicio { get; set; } = ""; // Piscina, Spa, Playa Privada, Restaurante, etc.

        // Propiedad de navegación
        [ForeignKey(nameof(HotelId))]
        public virtual Hotel? Hotel { get; set; }
    }
}
