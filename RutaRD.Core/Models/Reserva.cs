using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutaRD.Core.Models
{
    [Table("Reservas")]
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreCliente { get; set; } = "";

        [Required]
        [MaxLength(150)]
        public string Correo { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; } = "";

        [Required]
        public DateTime FechaEntrada { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; }

        public int Noches { get; set; }

        [Required]
        public int Adultos { get; set; } = 1;

        public int Ninos { get; set; } = 0;

        [Required]
        public int Habitaciones { get; set; } = 1;

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioNoche { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalEstimado { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ITBIS { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalConITBIS { get; set; }

        public string? SolicitudesEspeciales { get; set; } = "";

        [MaxLength(30)]
        public string? NumeroFactura { get; set; } = "";

        public DateTime FechaReserva { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(20)]
        public string Estado { get; set; } = "Pendiente"; // Pendiente, Confirmada, Cancelada

        // Propiedades de navegación
        [ForeignKey(nameof(UsuarioId))]
        public virtual Usuario? Usuario { get; set; }

        [ForeignKey(nameof(HotelId))]
        public virtual Hotel? Hotel { get; set; }
    }
}
