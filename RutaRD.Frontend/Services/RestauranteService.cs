using Frontend.Models;

namespace Frontend.Services
{
    public class RestauranteService
    {
        public List<Restaurante> GetRestaurantes()
        {
            return new List<Restaurante>
            {
                new Restaurante
                {
                    Id = 1,
                    Nombre = "Casita Azul",
                    Descripcion = "Es un lugar con un estilo coqueto, alusivo a un hogar de la etapa colonial.",
                    Imagen = "images/restaurantes/casita-azul.jpg",
                    Ubicacion = "C. Beller No.40, Centro Histórico, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Casita+Azul+Puerto+Plata",
                    Estrellas = 5,
                    Telefono = "+1 +18095863718",
                    SitioWeb = "https://instagram.com/lacasitaazulpop?igshid=1t7tgpz3sn3b0", 
                    RangoPrecios = "$$",
                    OpcionVegetariana = true,
                    OpcionVegana = false,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Isabella Méndez", Comentario = "La comida es excelente y el servicio es muy amable. Volveré sin duda.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Javier Reyes", Comentario = "Excelente comida dominicana auténtica. El mofongo de camarones es espectacular.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Restaurante
                {
                    Id = 2,
                    Nombre = "La Tarappa",
                    Descripcion = "Restaurante con un ambiente acogedor y una decoración que mezcla lo rústico con lo moderno.",
                    Imagen = "images/restaurantes/tarappa.jpg",
                    Ubicacion = "Calle Privada #2, Av. Hermanas Mirabal Esq, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=La+Tarappa+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+18092612423",
                    SitioWeb = "https://www.latarappa.com/", 
                    RangoPrecios = "$$$",
                    OpcionVegetariana = true,
                    OpcionVegana = false,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Sofia Herrera", Comentario = "Excelente la pasta, las pizzas y el ambiente.", Calificacion = 4, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Miguel Torres", Comentario = "Muy buen restaurante, la atención es excelente y la comida es deliciosa.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Restaurante 
                {
                    Id = 3,
                    Nombre = "Le petit François",
                    Descripcion = "Restaurante con un ambiente elegante y una decoración que mezcla lo clásico con lo contemporáneo.",
                    Imagen = "images/restaurantes/le-petit-francois.jpg",
                    Ubicacion = "Playa Dorada, G1, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Le+petit+François+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+18294922910",
                    SitioWeb = "https://lepetitfrancois.com/",
                    RangoPrecios = "$$",
                    OpcionVegetariana = true,
                    OpcionVegana = false,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Isabella Méndez", Comentario = "La comida es excelente y el servicio es muy amable. Volveré sin duda.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Javier Reyes", Comentario = "Excelente comida dominicana auténtica. El mofongo de camarones es espectacular.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Restaurante
                {
                    Id = 4,
                    Nombre = "Fresh Fresh Puerto Plata",
                    Descripcion = "Restaurante con un ambiente fresco y moderno, especializado en comida saludable y opciones vegetarianas.",
                    Imagen = "images/restaurantes/fresh-fresh.jpg",
                    Ubicacion = "C. Duarte, Centro Histórico, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Fresh+Fresh+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+18495067676",
                    SitioWeb = "https://www.instagram.com/freshfreshpop/?hl=en",
                    RangoPrecios = "$",
                    OpcionVegetariana = true,
                    OpcionVegana = true,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Isabella García", Comentario = "Excelente restaurante para comer saludable.", Calificacion = 4, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Santiago Fernández", Comentario = "Muy buen restaurante, ideal para una ocasión especial. La comida es deliciosa y el servicio es excelente.", Calificacion = 4, Fecha = "Diciembre 2025" }
                    }
                },
                new Restaurante
                {
                    Id = 5,
                    Nombre = "Skina Restaurante",
                    Descripcion = "Restaurante con un ambiente elegante y una decoración que mezcla lo clásico con lo contemporáneo.",
                    Imagen = "images/restaurantes/skina.jpg",
                    Ubicacion = "C. Separación, Centro Histórico, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Skina+Restaurante+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+18099701950",
                    SitioWeb = "https://www.instagram.com/skina_restaurante/?hl=en", 
                    RangoPrecios = "$",
                    OpcionVegetariana = false,
                    OpcionVegana = false,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Valentina López", Comentario = "Excelente opción para probar la comida casera dominicana. El sancocho es delicioso.", Calificacion = 4, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Diego Ramírez", Comentario = "Muy buen restaurante, ideal para una comida familiar. La comida es deliciosa y el ambiente es acogedor.", Calificacion = 4, Fecha = "Diciembre 2025" }
                    }
                },
                new Restaurante
                {
                    Id = 6,
                    Nombre = "Lokura's PoP",
                    Descripcion = "Restaurante con un ambiente divertido y una decoración que mezcla lo moderno con lo urbano.",
                    Imagen = "images/restaurantes/lokuras.jpg",
                    Ubicacion = "Prof. Juan Bosch casi esq, C. 30 de Marzo, Centro Histórico, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Lokura's+PoP+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+18095868052",
                    SitioWeb = "https://www.instagram.com/lokuras_pop/?hl=en",
                    RangoPrecios = "$$",
                    OpcionVegetariana = false,
                    OpcionVegana = false,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Isabella García", Comentario = "Excelente restaurante para los amantes de la carne. La parrillada es espectacular.", Calificacion = 4, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Santiago Fernández", Comentario = "Muy buen restaurante, ideal para una comida informal. La comida es deliciosa y el ambiente es agradable.", Calificacion = 4, Fecha = "Diciembre 2025" }
                    }
                }
            };
        }

        public Restaurante? GetRestaurante(int id) =>
            GetRestaurantes().FirstOrDefault(r => r.Id == id);
    }
}