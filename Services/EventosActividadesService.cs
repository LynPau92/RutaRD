using Frontend.Models;

namespace Frontend.Services
{
    public class EventosActividadesService
    {
        public List<EventosActividades> GetEventos()
        {
            return new List<EventosActividades>
            {
                new EventosActividades
                {
                    Id = 1,
                    Nombre = "Ocean World Adventure Park",
                    Descripcion = "Parque acuático con delfines, tiburones, leones marinos y snorkel en arrecifes de coral. Una experiencia única para toda la familia.",
                    Imagen = "images/eventos/ocean-world.jpg",
                    Ubicacion = "Cofresí, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Ocean+World+Adventure+Park+Puerto+Plata",
                    SitioWeb = "https://www.oceanworld.net",
                    Tipo = "Actividad",
                    Fecha = "Todo el año",
                    Horario = "9:00am - 5:00pm",
                    PrecioEntrada = "US$69 adultos / US$49 niños",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Mariana Ortiz", Comentario = "Los delfines son increíbles y el personal muy profesional. Una experiencia que no olvidaré.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Roberto Féliz", Comentario = "Perfecto para niños y adultos. El show de leones marinos es espectacular.", Calificacion = 5, Fecha = "Enero 2026" }
                    }
                },
                new EventosActividades
                {
                    Id = 2,
                    Nombre = "Carnaval de Puerto Plata",
                    Descripcion = "Uno de los carnavales más coloridos y tradicionales de República Dominicana con disfraces, comparsas y música típica dominicana.",
                    Imagen = "images/eventos/carnaval.jpg",
                    Ubicacion = "Malecón, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Malecon+Puerto+Plata",
                    SitioWeb = "#",
                    Tipo = "Festival",
                    Fecha = "Febrero - Marzo",
                    Horario = "4:00pm - 10:00pm",
                    PrecioEntrada = "Gratis",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Yolanda Méndez", Comentario = "El carnaval de Puerto Plata es una explosión de color y alegría. Una tradición dominicana única.", Calificacion = 5, Fecha = "Marzo 2025" },
                        new Resena { Id = 2, NombreVisitante = "Santiago Brito", Comentario = "Los disfraces son increíbles y la música contagiosa. Volveré el próximo año.", Calificacion = 5, Fecha = "Febrero 2025" }
                    }
                },
                new EventosActividades
                {
                    Id = 3,
                    Nombre = "Teleférico de Puerto Plata",
                    Descripcion = "Recorrido en teleférico hasta la cima del Pico Isabel de Torres con jardín botánico y vistas panorámicas de la ciudad y el mar.",
                    Imagen = "images/eventos/teleferico.jpg",
                    Ubicacion = "Puerto Plata Centro",
                    GoogleMapsUrl = "https://maps.google.com/?q=Teleferico+Puerto+Plata",
                    SitioWeb = "#",
                    Tipo = "Actividad",
                    Fecha = "Todo el año",
                    Horario = "8:00am - 5:00pm",
                    PrecioEntrada = "RD$500",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Diana Suero", Comentario = "Las vistas desde arriba son impresionantes. Se puede ver toda la ciudad y el océano.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Manuel Pichardo", Comentario = "Una experiencia única. El jardín botánico en la cima es hermoso y muy bien cuidado.", Calificacion = 4, Fecha = "Febrero 2026" }
                    }
                },
                new EventosActividades
                {
                    Id = 4,
                    Nombre = "Festival del Merengue Puerto Plata",
                    Descripcion = "Festival musical anual en el Malecón con las mejores orquestas de merengue y bachata del país.",
                    Imagen = "images/eventos/merengue.jpg",
                    Ubicacion = "Malecón, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Malecon+Puerto+Plata",
                    SitioWeb = "#",
                    Tipo = "Festival",
                    Fecha = "Octubre",
                    Horario = "6:00pm - 12:00am",
                    PrecioEntrada = "Gratis",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Cecilia Reyes", Comentario = "El mejor festival de merengue del país. La energía del Malecón es indescriptible.", Calificacion = 5, Fecha = "Octubre 2025" },
                        new Resena { Id = 2, NombreVisitante = "Víctor Almánzar", Comentario = "Música, baile y gastronomía dominicana en su máxima expresión. Imperdible.", Calificacion = 5, Fecha = "Octubre 2025" }
                    }
                },
                new EventosActividades
                {
                    Id = 5,
                    Nombre = "Kitesurf en Cabarete",
                    Descripcion = "Cabarete es reconocida mundialmente como capital del kitesurf. Clases para principiantes y avanzados con instructores certificados.",
                    Imagen = "images/eventos/kitesurf.jpg",
                    Ubicacion = "Cabarete, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Kitesurf+Cabarete+Puerto+Plata",
                    SitioWeb = "#",
                    Tipo = "Actividad",
                    Fecha = "Todo el año",
                    Horario = "8:00am - 5:00pm",
                    PrecioEntrada = "US$80 por clase",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Paola Then", Comentario = "Aprendí kitesurf en 3 días. Los instructores son pacientes y muy profesionales.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Cristian Nova", Comentario = "El viento en Cabarete es perfecto para el kitesurf. Una experiencia adrenalínica.", Calificacion = 5, Fecha = "Febrero 2026" }
                    }
                },
                new EventosActividades
                {
                    Id = 6,
                    Nombre = "Tour Fortaleza San Felipe",
                    Descripcion = "Visita guiada a la fortaleza colonial más antigua del hemisferio occidental, construida en el siglo XVI.",
                    Imagen = "images/eventos/fortaleza.jpg",
                    Ubicacion = "Puerto Plata Centro",
                    GoogleMapsUrl = "https://maps.google.com/?q=Fortaleza+San+Felipe+Puerto+Plata",
                    SitioWeb = "#",
                    Tipo = "Actividad",
                    Fecha = "Todo el año",
                    Horario = "9:00am - 5:00pm",
                    PrecioEntrada = "RD$100",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Isabel Acosta", Comentario = "El tour guiado es muy completo. Aprendí mucho sobre la historia colonial dominicana.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Francisco Lora", Comentario = "Una joya histórica. Los cañones y las mazmorras son fascinantes.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new EventosActividades
                {
                    Id = 7,
                    Nombre = "Cabarete Race Week",
                    Descripcion = "Competencia internacional de windsurf y kitesurf que atrae a atletas de más de 30 países.",
                    Imagen = "images/eventos/raceweek.jpg",
                    Ubicacion = "Cabarete, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Cabarete+Puerto+Plata",
                    SitioWeb = "https://www.cabarete-raceweek.com",
                    Tipo = "Festival",
                    Fecha = "Junio",
                    Horario = "Todo el día",
                    PrecioEntrada = "Gratis para espectadores",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Adriana Castillo", Comentario = "Ver a los mejores kitesurfistas del mundo compitiendo en Cabarete es emocionante.", Calificacion = 5, Fecha = "Junio 2025" },
                        new Resena { Id = 2, NombreVisitante = "Eduardo Mena", Comentario = "Un evento de clase mundial en una playa paradisíaca. Puerto Plata en su mejor versión.", Calificacion = 5, Fecha = "Junio 2025" }
                    }
                }
            };
        }

        public EventosActividades? GetEvento(int id) =>
            GetEventos().FirstOrDefault(e => e.Id == id);
    }
}