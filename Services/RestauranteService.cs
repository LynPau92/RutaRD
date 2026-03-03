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
                    Nombre = "La Malecón Restaurant",
                    Descripcion = "Restaurante frente al mar con especialidades en mariscos y comida dominicana.",
                    Imagen = "images/restaurantes/malecon.jpg",
                    Ubicacion = "Malecón, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=La+Malecon+Restaurant+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+1 (809) 320-1111",
                    SitioWeb = "#",
                    RangoPrecios = "$$",
                    OpcionVegetariana = true,
                    OpcionVegana = false,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Isabella Méndez", Comentario = "Los mariscos son fresquísimos y la vista al mar es incomparable. Volveré sin duda.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Javier Reyes", Comentario = "Excelente comida dominicana auténtica. El mofongo de camarones es espectacular.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Restaurante
                {
                    Id = 2,
                    Nombre = "El Paraíso Beach Bar",
                    Descripcion = "Bar y restaurante casual en la playa con cócteles tropicales y frituras.",
                    Imagen = "images/restaurantes/paraiso.jpg",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=El+Paraiso+Beach+Bar+Puerto+Plata",
                    Estrellas = 4,
                    Telefono = "+1 (809) 320-2222",
                    SitioWeb = "#",
                    RangoPrecios = "$",
                    OpcionVegetariana = true,
                    OpcionVegana = true,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Camila Vargas", Comentario = "Ambiente increíble en la playa, los cócteles tropicales son deliciosos y el precio muy accesible.", Calificacion = 4, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Andrés López", Comentario = "Perfecto para almorzar con los pies en la arena. Las opciones veganas son muy buenas.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new Restaurante
                {
                    Id = 3,
                    Nombre = "Aguaceros Restaurant",
                    Descripcion = "Cocina dominicana auténtica con vista panorámica a la ciudad.",
                    Imagen = "images/restaurantes/aguaceros.jpg",
                    Ubicacion = "Puerto Plata Centro",
                    GoogleMapsUrl = "https://maps.google.com/?q=Aguaceros+Restaurant+Puerto+Plata",
                    Estrellas = 5,
                    Telefono = "+1 (809) 320-3333",
                    SitioWeb = "#",
                    RangoPrecios = "$$$",
                    OpcionVegetariana = false,
                    OpcionVegana = false,
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Valentina Cruz", Comentario = "La mejor experiencia gastronómica de Puerto Plata. La vista panorámica es simplemente impresionante.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Diego Morales", Comentario = "Comida dominicana de alta cocina. El sancocho y el chivo guisado son excepcionales.", Calificacion = 5, Fecha = "Enero 2026" }
                    }
                }
            };
        }

        public Restaurante? GetRestaurante(int id) =>
            GetRestaurantes().FirstOrDefault(r => r.Id == id);
    }
}