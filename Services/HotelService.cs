using Frontend.Models;

namespace Frontend.Services
{
    public class HotelService
    {
        public List<Hotel> GetHoteles()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    Id = 1,
                    Nombre = "Casa Colonial Beach & Spa",
                    Descripcion = "Hotel boutique de lujo frente al mar en Playa Dorada.",
                    Imagen = "images/hoteles/casa-colonial.jpg",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Casa+Colonial+Beach+Spa+Puerto+Plata",
                    Estrellas = 5,
                    Telefono = "+1 (809) 320-3232",
                    SitioWeb = "https://www.casacolonial.com",
                    Tipo = "Boutique",
                    Servicios = new List<string> { "Piscina", "Spa", "Playa Privada" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "María González", Comentario = "Increíble experiencia, el servicio es de primera y las vistas al mar son espectaculares.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Carlos Martínez", Comentario = "Hotel de lujo con una atención al cliente excelente. Lo recomiendo totalmente.", Calificacion = 5, Fecha = "Febrero 2026" }
                    }
                },
                new Hotel
                {
                    Id = 2,
                    Nombre = "Iberostar Costa Dorada",
                    Descripcion = "Resort todo incluido con playa privada y múltiples piscinas.",
                    Imagen = "images/hoteles/iberostar.jpg",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Iberostar+Costa+Dorada+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+1 (809) 320-1000",
                    SitioWeb = "https://www.iberostar.com",
                    Tipo = "Todo Incluido",
                    Servicios = new List<string> { "Piscina", "Playa Privada", "Restaurante" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Ana Rodríguez", Comentario = "Excelente resort, la comida es variada y deliciosa. La playa es hermosa.", Calificacion = 4, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Pedro Sánchez", Comentario = "Muy buen todo incluido, perfecto para familias con niños.", Calificacion = 4, Fecha = "Diciembre 2025" }
                    }
                },
                new Hotel
                {
                    Id = 3,
                    Nombre = "BlueBay Villas Doradas",
                    Descripcion = "Resort adults-only con ambiente relajado frente al mar.",
                    Imagen = "images/hoteles/bluebay.jpg",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=BlueBay+Villas+Doradas+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+1 (809) 320-3000",
                    SitioWeb = "https://www.bluebayresorts.com",
                    Tipo = "Resort",
                    Servicios = new List<string> { "Piscina", "Spa", "Playa Privada", "Restaurante" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Laura Pérez", Comentario = "Perfecto para una escapada romántica. Tranquilo, limpio y con un spa increíble.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Roberto Díaz", Comentario = "Excelente ambiente para adultos, muy relajante y el personal muy atento.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Hotel
                {
                    Id = 4,
                    Nombre = "Emotion by Hodelpa",
                    Descripcion = "Hotel moderno en el centro de Puerto Plata con piscina y spa.",
                    Imagen = "images/hoteles/emotion.jpg",
                    Ubicacion = "Puerto Plata Centro",
                    GoogleMapsUrl = "https://maps.google.com/?q=Emotion+by+Hodelpa+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+1 (809) 320-2222",
                    SitioWeb = "https://www.hodelpa.com",
                    Tipo = "Boutique",
                    Servicios = new List<string> { "Piscina", "Spa", "Restaurante" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Sofia Herrera", Comentario = "Ubicación céntrica perfecta para explorar la ciudad. Habitaciones modernas y cómodas.", Calificacion = 4, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Miguel Torres", Comentario = "Muy buen hotel, limpio y con un excelente desayuno buffet.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                }
            };
        }

        public Hotel? GetHotel(int id) =>
            GetHoteles().FirstOrDefault(h => h.Id == id);
    }
}