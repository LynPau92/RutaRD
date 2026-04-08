namespace Frontend.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int HotelId { get; set; }
        public string NombreHotel { get; set; } = "";
        public string NombreCliente { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Telefono { get; set; } = "";
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Noches { get; set; }
        public int Adultos { get; set; } = 1;
        public int Ninos { get; set; } = 0;
        public int Habitaciones { get; set; } = 1;
        public decimal PrecioNoche { get; set; }
        public decimal TotalEstimado { get; set; }
        public decimal ITBIS { get; set; }
        public decimal TotalConITBIS { get; set; }
        public string? SolicitudesEspeciales { get; set; }
        public string? NumeroFactura { get; set; } = "";
        public DateTime FechaReserva { get; set; } = DateTime.UtcNow;
        public string Estado { get; set; } = "Pendiente"; // Pendiente, Confirmada, Cancelada

        // Propiedades de navegación
        public Hotel? Hotel { get; set; }

        // Propiedades calculadas para compatibilidad con código existente
        public int NochesCalculadas => (FechaSalida - FechaEntrada).Days;
        public decimal TotalCalculado => Noches * PrecioNoche * Habitaciones * (Adultos + (Ninos * 0.60m));
    }
}