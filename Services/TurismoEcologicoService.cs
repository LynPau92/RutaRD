using Frontend.Models;

namespace Frontend.Services
{
    public class TurismoEcologicoService
    {
        public List<TurismoEcologico> GetLugares()
        {
            return new List<TurismoEcologico>
            {
                new TurismoEcologico
                {
                    Id = 1,
                    Nombre = "Playa Dorada",
                    Descripcion = "Una de las playas más famosas de Puerto Plata, con arena blanca y aguas cristalinas.",
                    Imagen = "images/ecologico/playa-dorada.jpg",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Playa+Dorada+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Playa",
                    TipoActividad = "Nado, Snorkel, Surf",
                    NivelDificultad = "Fácil",
                    PrecioEntrada = "Gratis",
                    Horario = "6:00am - 6:00pm",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Gabriela Núñez", Comentario = "Arena blanca y aguas tranquilas, perfecta para toda la familia.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Ramón Castro", Comentario = "Una de las mejores playas del Caribe, el agua es cristalina y el ambiente muy tranquilo.", Calificacion = 5, Fecha = "Enero 2026" }
                    }
                },
                new TurismoEcologico
                {
                    Id = 2,
                    Nombre = "Pico Isabel de Torres",
                    Descripcion = "Montaña icónica de Puerto Plata con teleférico y jardín botánico en la cima.",
                    Imagen = "images/ecologico/pico-isabel.jpg",
                    Ubicacion = "Puerto Plata Centro",
                    GoogleMapsUrl = "https://maps.google.com/?q=Pico+Isabel+de+Torres+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Montaña",
                    TipoActividad = "Senderismo, Teleférico",
                    NivelDificultad = "Moderado",
                    PrecioEntrada = "RD$500",
                    Horario = "8:00am - 5:00pm",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Patricia Almonte", Comentario = "El teleférico es una experiencia única. Las vistas desde la cima son impresionantes.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Fernando Polanco", Comentario = "El jardín botánico en la cima es hermoso. Vale la pena cada peso.", Calificacion = 4, Fecha = "Febrero 2026" }
                    }
                },
                new TurismoEcologico
                {
                    Id = 3,
                    Nombre = "27 Charcos de Damajagua",
                    Descripcion = "Sistema de cascadas naturales y pozas de agua turquesa únicas en el mundo.",
                    Imagen = "images/ecologico/damajagua.jpg",
                    Ubicacion = "Imbert, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=27+Charcos+Damajagua+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Río",
                    TipoActividad = "Nado, Senderismo, Rappel",
                    NivelDificultad = "Moderado",
                    PrecioEntrada = "RD$800",
                    Horario = "8:00am - 3:00pm",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Luisa Taveras", Comentario = "Una aventura increíble. El agua turquesa y las cascadas son mágicas. ¡Imperdible!", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Carlos Batista", Comentario = "La mejor excursión de mi vida. Los guías son muy profesionales y el lugar es espectacular.", Calificacion = 5, Fecha = "Enero 2026" }
                    }
                },
                new TurismoEcologico
                {
                    Id = 4,
                    Nombre = "Playa Cabarete",
                    Descripcion = "Capital mundial del kitesurf con playas de arena blanca y ambiente vibrante.",
                    Imagen = "images/ecologico/cabarete.jpg",
                    Ubicacion = "Cabarete, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Playa+Cabarete+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Playa",
                    TipoActividad = "Kitesurf, Windsurf, Nado",
                    NivelDificultad = "Moderado",
                    PrecioEntrada = "Gratis",
                    Horario = "Abierto todo el día",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Ana Jiménez", Comentario = "Ambiente increíble, ideal para los amantes del kitesurf. El viento es perfecto.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Pablo Rosario", Comentario = "Cabarete tiene una energía única. Las clases de kitesurf son muy buenas.", Calificacion = 4, Fecha = "Febrero 2026" }
                    }
                },
                new TurismoEcologico
                {
                    Id = 5,
                    Nombre = "Sendero El Choco",
                    Descripcion = "Parque nacional con cuevas, lagunas y senderos naturales rodeados de vegetación.",
                    Imagen = "images/ecologico/el-choco.jpg",
                    Ubicacion = "Cabarete, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Parque+Nacional+El+Choco+Cabarete",
                    SitioWeb = "#",
                    TipoLugar = "Sendero",
                    TipoActividad = "Senderismo, Kayak, Espeleología",
                    NivelDificultad = "Moderado",
                    PrecioEntrada = "RD$300",
                    Horario = "8:00am - 4:00pm",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Elena Marte", Comentario = "Las cuevas son impresionantes y la laguna es preciosa. Una joya escondida.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "José Antigua", Comentario = "Perfecto para los amantes de la naturaleza. El kayak en la laguna es una experiencia única.", Calificacion = 4, Fecha = "Febrero 2026" }
                    }
                },
                new TurismoEcologico
                {
                    Id = 6,
                    Nombre = "Playa Sosúa",
                    Descripcion = "Bahía protegida ideal para el snorkel con arrecifes de coral y aguas tranquilas.",
                    Imagen = "images/ecologico/sosua.jpg",
                    Ubicacion = "Sosúa, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Playa+Sosua+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Playa",
                    TipoActividad = "Snorkel, Buceo, Nado",
                    NivelDificultad = "Fácil",
                    PrecioEntrada = "Gratis",
                    Horario = "Abierto todo el día",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Sandra Pérez", Comentario = "Los arrecifes de coral son espectaculares. El snorkel aquí es de otro nivel.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Miguel Ángel Reyes", Comentario = "Aguas tranquilas y cristalinas, perfectas para el buceo. La vida marina es increíble.", Calificacion = 5, Fecha = "Enero 2026" }
                    }
                }
            };
        }

        public TurismoEcologico? GetLugar(int id) =>
            GetLugares().FirstOrDefault(l => l.Id == id);
    }
}