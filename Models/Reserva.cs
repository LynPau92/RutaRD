namespace Frontend.Models
{
    public class Reserva
    {
        public int HotelId { get; set; }
        public string NombreHotel { get; set; } = "";
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Adultos { get; set; } = 1;
        public int Ninos { get; set; } = 0;
        public int Habitaciones { get; set; } = 1;
        public decimal PrecioNoche { get; set; }

        public int Noches => (FechaSalida - FechaEntrada).Days;
        public decimal TotalEstimado => Noches * PrecioNoche * Habitaciones * (Adultos + (Ninos * 0.60m));
    }
}