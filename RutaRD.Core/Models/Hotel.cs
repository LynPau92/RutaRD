using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutaRD.Core.Models
{
    [Table("Hoteles")]
    public class Hotel
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

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioNoche { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; } = "";

        [MaxLength(300)]
        public string? SitioWeb { get; set; } = "";

        [MaxLength(50)]
        public string? Tipo { get; set; } = ""; // Resort, Boutique, Todo Incluido

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación
        public virtual ICollection<HotelServicio> HotelServicios { get; set; } = new List<HotelServicio>();
        public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

        // Propiedad no mapeada para compatibilidad con frontend
        [NotMapped]
        public List<string> Servicios
        {
            get => HotelServicios.Select(hs => hs.Servicio).ToList();
            set => HotelServicios = value.Select(v => new HotelServicio { Servicio = v }).ToList();
        }
    }
}
