using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using RutaRD.Core.Models;

namespace RutaRD.Api.Data
{
    public static class DataSeeder
    {
        public static void Seed(RutaRDbContext context)
        {
            Console.WriteLine("🔄 Iniciando seed de datos...");

            // Verificar si ya existe el admin por defecto
            if (context.Usuarios.Any(u => u.Correo == "admin@rutard.com"))
            {
                Console.WriteLine("✓ Usuario admin ya existe");

                // Verificar si hay hoteles
                if (context.Hoteles.Any())
                {
                    Console.WriteLine("✓ Los hoteles ya existen en la base de datos");
                    return;
                }
                else
                {
                    Console.WriteLine("⚠ No hay hoteles. Insertando hoteles...");
                    SeedHoteles(context);
                    return;
                }
            }

            Console.WriteLine("📝 Creando usuario admin por defecto...");

            // Crear usuario admin por defecto
            var admin = new Usuario
            {
                Nombre = "Administrador",
                Correo = "admin@rutard.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Rol = "Administrador",
                FechaRegistro = DateTime.UtcNow
            };

            context.Usuarios.Add(admin);
            context.SaveChanges();

            Console.WriteLine("✓ Usuario admin creado: admin@rutard.com / Admin123!");

            // Insertar hoteles
            SeedHoteles(context);
        }

        private static void SeedHoteles(RutaRDbContext context)
        {
            if (context.Hoteles.Any())
            {
                Console.WriteLine("✓ Los hoteles ya existen en la base de datos.");
                return;
            }

            Console.WriteLine("🏨 Insertando 6 hoteles en la base de datos...");

            var hoteles = new List<Hotel>
            {
                new Hotel
                {
                    Nombre = "Casa Colonial Beach & Spa",
                    Descripcion = "Hotel boutique de lujo frente a la playa en Playa Dorada, reconocido por su elegante diseño colonial, spa de clase mundial y piscina infinity en la azotea con vistas panorámicas al mar.",
                    Imagen = "images/hoteles/casa-colonial.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Casa+Colonial+Beach+Spa+Puerto+Plata",
                    Estrellas = 5,
                    PrecioNoche = 8500.00m,
                    Telefono = "+1 (809) 320-3232",
                    SitioWeb = "https://www.casacolonialhotel.com",
                    Tipo = "Boutique"
                },
                new Hotel
                {
                    Nombre = "Iberostar Costa Dorada",
                    Descripcion = "Resort cinco estrellas frente al mar con arquitectura colonial caribeña, entretenimiento nocturno, spa y restaurantes internacionales.",
                    Imagen = "images/hoteles/iberostar.png",
                    Ubicacion = "Costa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Iberostar+Costa+Dorada+Puerto+Plata",
                    Estrellas = 5,
                    PrecioNoche = 7500.00m,
                    Telefono = "+1 (809) 320-1000",
                    SitioWeb = "https://www.iberostar.com",
                    Tipo = "Todo Incluido"
                },
                new Hotel
                {
                    Nombre = "BlueBay Villas Doradas",
                    Descripcion = "Resort solo para adultos ubicado en Playa Dorada, ideal para parejas y escapadas románticas, con spa y restaurantes gourmet.",
                    Imagen = "images/hoteles/bluebay.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=BlueBay+Villas+Doradas+Puerto+Plata",
                    Estrellas = 4,
                    PrecioNoche = 6500.00m,
                    Telefono = "+1 (809) 320-3000",
                    SitioWeb = "https://www.bluebayresorts.com",
                    Tipo = "Resort Solo Adultos"
                },
                new Hotel
                {
                    Nombre = "Emotions by Hodelpa",
                    Descripcion = "Resort todo incluido ubicado en Playa Dorada con acceso directo a la playa, múltiples restaurantes, spa y entretenimiento para toda la familia.",
                    Imagen = "images/hoteles/emotions.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Emotions+by+Hodelpa+Puerto+Plata",
                    Estrellas = 4,
                    PrecioNoche = 5500.00m,
                    Telefono = "+1 (809) 320-2222",
                    SitioWeb = "https://www.hodelpa.com",
                    Tipo = "Todo Incluido"
                },
                new Hotel
                {
                    Nombre = "VH Gran Ventana Beach Resort",
                    Descripcion = "Resort todo incluido ubicado en Playa Dorada, ideal para familias, con piscina, spa, restaurantes y acceso directo a la playa.",
                    Imagen = "images/hoteles/vh.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=VH+Gran+Ventana+Beach+Resort+Puerto+Plata",
                    Estrellas = 4,
                    PrecioNoche = 6000.00m,
                    Telefono = "+1 (809) 320-2111",
                    SitioWeb = "https://www.vhhr.com",
                    Tipo = "Todo Incluido"
                },
                new Hotel
                {
                    Nombre = "Sunscape Puerto Plata",
                    Descripcion = "Resort todo incluido ideal para familias, ubicado en Playa Dorada, con múltiples restaurantes, parque acuático y entretenimiento diario.",
                    Imagen = "images/hoteles/sunscape.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Sunscape+Puerto+Plata",
                    Estrellas = 4,
                    PrecioNoche = 5800.00m,
                    Telefono = "+1 (809) 320-5084",
                    SitioWeb = "https://www.hyattinclusivecollection.com",
                    Tipo = "Todo Incluido"
                }
            };

            context.Hoteles.AddRange(hoteles);
            context.SaveChanges();

            Console.WriteLine("✓ 6 hoteles insertados correctamente");

            Console.WriteLine("🛎️ Insertando servicios de los hoteles...");

            // Agregar servicios a los hoteles
            var hotelServicios = new List<HotelServicio>
            {
                // Hotel 1 - Casa Colonial
                new HotelServicio { HotelId = 1, Servicio = "Piscina Infinity" },
                new HotelServicio { HotelId = 1, Servicio = "Spa" },
                new HotelServicio { HotelId = 1, Servicio = "Restaurante Gourmet" },
                new HotelServicio { HotelId = 1, Servicio = "Playa privada" },
                new HotelServicio { HotelId = 1, Servicio = "Gimnasio" },
                new HotelServicio { HotelId = 1, Servicio = "WiFi" },

                // Hotel 2 - Iberostar
                new HotelServicio { HotelId = 2, Servicio = "Piscina" },
                new HotelServicio { HotelId = 2, Servicio = "Spa" },
                new HotelServicio { HotelId = 2, Servicio = "Restaurantes" },
                new HotelServicio { HotelId = 2, Servicio = "Casino cercano" },
                new HotelServicio { HotelId = 2, Servicio = "Playa privada" },
                new HotelServicio { HotelId = 2, Servicio = "Entretenimiento nocturno" },

                // Hotel 3 - BlueBay
                new HotelServicio { HotelId = 3, Servicio = "Piscina" },
                new HotelServicio { HotelId = 3, Servicio = "Spa" },
                new HotelServicio { HotelId = 3, Servicio = "Restaurantes gourmet" },
                new HotelServicio { HotelId = 3, Servicio = "Playa privada" },
                new HotelServicio { HotelId = 3, Servicio = "Bar" },
                new HotelServicio { HotelId = 3, Servicio = "WiFi" },

                // Hotel 4 - Emotions
                new HotelServicio { HotelId = 4, Servicio = "Piscina" },
                new HotelServicio { HotelId = 4, Servicio = "Spa" },
                new HotelServicio { HotelId = 4, Servicio = "Restaurante" },
                new HotelServicio { HotelId = 4, Servicio = "Playa Privada" },
                new HotelServicio { HotelId = 4, Servicio = "Gimnasio" },
                new HotelServicio { HotelId = 4, Servicio = "WiFi" },

                // Hotel 5 - VH Gran Ventana
                new HotelServicio { HotelId = 5, Servicio = "Piscina" },
                new HotelServicio { HotelId = 5, Servicio = "Restaurantes temáticos" },
                new HotelServicio { HotelId = 5, Servicio = "Playa privada" },
                new HotelServicio { HotelId = 5, Servicio = "Club infantil" },
                new HotelServicio { HotelId = 5, Servicio = "WiFi" },
                new HotelServicio { HotelId = 5, Servicio = "Bar" },

                // Hotel 6 - Sunscape
                new HotelServicio { HotelId = 6, Servicio = "Piscina" },
                new HotelServicio { HotelId = 6, Servicio = "Parque acuático" },
                new HotelServicio { HotelId = 6, Servicio = "Restaurantes" },
                new HotelServicio { HotelId = 6, Servicio = "Club infantil" },
                new HotelServicio { HotelId = 6, Servicio = "Playa privada" },
                new HotelServicio { HotelId = 6, Servicio = "WiFi" }
            };

            context.HotelServicios.AddRange(hotelServicios);
            context.SaveChanges();

            Console.WriteLine("✓ 36 servicios de hotel insertados");

            Console.WriteLine("⭐ Insertando reseñas de clientes...");

            // Agregar reseñas
            var resenas = new List<Resena>
            {
                // Hotel 1
                new Resena
                {
                    CategoriaId = 1,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "María González",
                    Comentario = "Increíble experiencia, el servicio es de primera y las vistas al mar son espectaculares.",
                    Calificacion = 5,
                    Fecha = DateTime.SpecifyKind(new DateTime(2026, 1, 15), DateTimeKind.Utc),
                    FechaFormateada = "Enero 2026"
                },
                new Resena
                {
                    CategoriaId = 1,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "Carlos Martínez",
                    Comentario = "Hotel de lujo con una atención al cliente excelente. Lo recomiendo totalmente.",
                    Calificacion = 5,
                    Fecha = DateTime.SpecifyKind(new DateTime(2026, 2, 10), DateTimeKind.Utc),
                    FechaFormateada = "Febrero 2026"
                },
                // Hotel 2
                new Resena
                {
                    CategoriaId = 2,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "Ana Rodríguez",
                    Comentario = "Excelente resort, la comida es variada y deliciosa. La playa es hermosa.",
                    Calificacion = 4,
                    Fecha = DateTime.SpecifyKind(new DateTime(2026, 1, 20), DateTimeKind.Utc),
                    FechaFormateada = "Enero 2026"
                },
                new Resena
                {
                    CategoriaId = 2,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "Pedro Sánchez",
                    Comentario = "Muy buen todo incluido, perfecto para familias con niños.",
                    Calificacion = 4,
                    Fecha = DateTime.SpecifyKind(new DateTime(2025, 12, 15), DateTimeKind.Utc),
                    FechaFormateada = "Diciembre 2025"
                },
                // Hotel 3
                new Resena
                {
                    CategoriaId = 3,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "Laura Pérez",
                    Comentario = "Perfecto para una escapada romántica. Tranquilo, limpio y con un spa increíble.",
                    Calificacion = 5,
                    Fecha = DateTime.SpecifyKind(new DateTime(2026, 2, 5), DateTimeKind.Utc),
                    FechaFormateada = "Febrero 2026"
                },
                // Hotel 4
                new Resena
                {
                    CategoriaId = 4,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "Sofia Herrera",
                    Comentario = "Ubicación céntrica perfecta para explorar la ciudad. Habitaciones modernas y cómodas.",
                    Calificacion = 4,
                    Fecha = DateTime.SpecifyKind(new DateTime(2026, 2, 12), DateTimeKind.Utc),
                    FechaFormateada = "Febrero 2026"
                },
                // Hotel 5
                new Resena
                {
                    CategoriaId = 5,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "Valentina López",
                    Comentario = "Excelente opción para familias, la piscina es fantástica y la comida muy buena.",
                    Calificacion = 4,
                    Fecha = DateTime.SpecifyKind(new DateTime(2026, 1, 18), DateTimeKind.Utc),
                    FechaFormateada = "Enero 2026"
                },
                // Hotel 6
                new Resena
                {
                    CategoriaId = 6,
                    CategoriaTipo = "Hotel",
                    NombreVisitante = "Isabella García",
                    Comentario = "Muy buen resort, ideal para familias. La comida es excelente y la playa es hermosa.",
                    Calificacion = 4,
                    Fecha = DateTime.SpecifyKind(new DateTime(2026, 1, 22), DateTimeKind.Utc),
                    FechaFormateada = "Enero 2026"
                }
            };

            context.Resenas.AddRange(resenas);
            context.SaveChanges();

            Console.WriteLine($"✓ {resenas.Count} reseñas insertadas");
            Console.WriteLine($"🎉 Seed completado: {hoteles.Count} hoteles, {hotelServicios.Count} servicios, {resenas.Count} reseñas");
        }
    }
}
