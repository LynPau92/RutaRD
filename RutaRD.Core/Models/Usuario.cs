using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutaRD.Core.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = "";

        [Required]
        [MaxLength(150)]
        [Index(IsUnique = true)]
        public string Correo { get; set; } = "";

        [Required]
        [MaxLength(255)]
        public string Contrasena { get; set; } = ""; // Debe almacenarse como hash BCrypt

        [Required]
        [MaxLength(20)]
        public string Rol { get; set; } = "Cliente"; // 'Cliente' o 'Administrador'

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Propiedad de navegación
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
