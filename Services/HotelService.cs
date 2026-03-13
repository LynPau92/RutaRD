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
                    Descripcion = "Hotel boutique de lujo frente a la playa en Playa Dorada, reconocido por su elegante diseño colonial, spa de clase mundial y piscina infinity en la azotea con vistas panorámicas al mar.",
                    Imagen = "images/hoteles/casa-colonial.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Casa+Colonial+Beach+Spa+Puerto+Plata",
                    Estrellas = 5,
                    PrecioNoche = 8500.00m,
                    Telefono = "+1 (809) 320-3232",
                    SitioWeb = "https://www.casacolonialhotel.com",
                    Tipo = "Boutique",
                    Servicios = new List<string> { "Piscina Infinity", "Spa", "Restaurante Gourmet", "Playa privada", "Gimnasio", "WiFi" },
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
                    Descripcion = "Resort cinco estrellas frente al mar con arquitectura colonial caribeña, entretenimiento nocturno, spa y restaurantes internacionales.",
                    Imagen = "images/hoteles/iberostar.png",
                    Ubicacion = "Costa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Iberostar+Costa+Dorada+Puerto+Plata",
                    Estrellas = 5,
                    PrecioNoche = 7500.00m,
                    Telefono = "+1 (809) 320-1000",
                    SitioWeb = "https://www.iberostar.com",
                    Tipo = "Todo Incluido",
                    Servicios = new List<string> { "Piscina", "Spa", "Restaurantes", "Casino cercano", "Playa privada", "Entretenimiento nocturno" },
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
                    Descripcion = "Resort solo para adultos ubicado en Playa Dorada, ideal para parejas y escapadas románticas, con spa y restaurantes gourmet.",
                    Imagen = "images/hoteles/bluebay.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=BlueBay+Villas+Doradas+Puerto+Plata",
                    Estrellas = 4,
                    PrecioNoche = 6500.00m,
                    Telefono = "+1 (809) 320-3000",
                    SitioWeb = "https://www.bluebayresorts.com",
                    Tipo = "Resort Solo Adultos",
                    Servicios = new List<string> { "Piscina", "Spa", "Restaurantes gourmet", "Playa privada", "Bar", "WiFi" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Laura Pérez", Comentario = "Perfecto para una escapada romántica. Tranquilo, limpio y con un spa increíble.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Roberto Díaz", Comentario = "Excelente ambiente para adultos, muy relajante y el personal muy atento.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Hotel
                {
                    Id = 4,
                    Nombre = "Emotions by Hodelpa",
                    Descripcion = "Resort todo incluido ubicado en Playa Dorada con acceso directo a la playa, múltiples restaurantes, spa y entretenimiento para toda la familia.",
                    Imagen = "images/hoteles/emotions.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Emotions+by+Hodelpa+Puerto+Plata",
                    Estrellas = 4,
                    PrecioNoche = 5500.00m,
                    Telefono = "+1 (809) 320-2222",
                    SitioWeb = "https://www.hodelpa.com",
                    Tipo = "Todo Incluido",
                    Servicios = new List<string> { "Piscina", "Spa", "Restaurante", "Playa Privada", "Gimnasio", "WiFi" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Sofia Herrera", Comentario = "Ubicación céntrica perfecta para explorar la ciudad. Habitaciones modernas y cómodas.", Calificacion = 4, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Miguel Torres", Comentario = "Muy buen hotel, limpio y con un excelente desayuno buffet.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Hotel
                {
                    Id = 5,
                    Nombre = "VH Gran Ventana Beach Resort",
                    Descripcion = "Resort todo incluido ubicado en Playa Dorada, ideal para familias, con piscina, spa, restaurantes y acceso directo a la playa.",
                    Imagen = "images/hoteles/vh.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=VH+Gran+Ventana+Beach+Resort+Puerto+Plata",
                    Estrellas = 4,
                    PrecioNoche = 6000.00m,
                    Telefono = "+1 (809) 320-2111",
                    SitioWeb = "https://www.vhhr.com",
                    Tipo = "Todo Incluido",
                    Servicios = new List<string> { "Piscina", "Restaurantes temáticos", "Playa privada", "Club infantil", "WiFi", "Bar" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Valentina López", Comentario = "Excelente opción para familias, la piscina es fantástica y la comida muy buena.", Calificacion = 4, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Diego Ramírez", Comentario = "Muy buen resort con acceso directo a la playa. Ideal para relajarse y disfrutar en familia.", Calificacion = 4, Fecha = "Diciembre 2025" }
                    }
                },
                new Hotel
                {
                    Id = 6,
                    Nombre = "Sunscape Puerto Plata",
                    Descripcion = "Resort todo incluido ideal para familias, ubicado en Playa Dorada, con múltiples restaurantes, parque acuático y entretenimiento diario.",
                    Imagen = "images/hoteles/sunscape.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Sunscape+Puerto+Plata",
                    Estrellas = 4,  
                    PrecioNoche = 5800.00m,
                    Telefono = "+1 (809) 320-5084",
                    SitioWeb = "https://www.hyattinclusivecollection.com",
                    Tipo = "Todo Incluido",
                    Servicios = new List<string> { "Piscina", "Parque acuático", "Restaurantes", "Club infantil", "Playa privada", "WiFi" },
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Isabella García", Comentario = "Muy buen resort, ideal para familias. La comida es excelente y la playa es hermosa.", Calificacion = 4, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Santiago Fernández", Comentario = "Excelente opción para unas vacaciones en familia. El personal es muy amable y las instalaciones son de primera.", Calificacion = 4, Fecha = "Diciembre 2025" }
                    }
            }
            };
        }

        public Hotel? GetHotel(int id) =>
            GetHoteles().FirstOrDefault(h => h.Id == id);
    }
}