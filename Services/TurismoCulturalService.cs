using Frontend.Models;

namespace Frontend.Services
{
    public class TurismoCulturalService
    {
        public List<TurismoCultural> GetLugares()
        {
            return new List<TurismoCultural>
            {
                new TurismoCultural
                {
                    Id = 1,
                    Nombre = "Fortaleza San Felipe",
                    Descripcion = "La fortaleza colonial más antigua del hemisferio occidental, construida en el siglo XVI para defender la ciudad de ataques piratas. Hoy es un museo con armas, cañones y objetos históricos.",
                    Imagen = "images/cultural/fortaleza-san-felipe.jpg",
                    Ubicacion = "Malecón, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Fortaleza+San+Felipe+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Fortaleza",
                    Horario = "9:00am - 5:00pm",
                    PrecioEntrada = "RD$100",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Carmen Valdez", Comentario = "Historia viva de la República Dominicana. Los guías son muy conocedores y apasionados.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Antonio Mejía", Comentario = "Impresionante construcción colonial. La vista al mar desde la fortaleza es espectacular.", Calificacion = 5, Fecha = "Enero 2026" }
                    }
                },
                new TurismoCultural
                {
                    Id = 2,
                    Nombre = "Museo del Ámbar",
                    Descripcion = "Museo dedicado al ámbar dominicano, considerado el mejor del mundo. Exhibe piezas únicas con insectos prehistóricos atrapados, incluido el famoso ámbar con mosquito de Jurassic Park.",
                    Imagen = "images/cultural/museo-ambar.jpg",
                    Ubicacion = "Calle Duarte, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Museo+del+Ambar+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Museo",
                    Horario = "9:00am - 6:00pm",
                    PrecioEntrada = "US$5",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Rosa Espinal", Comentario = "Fascinante. Ver insectos de millones de años atrapados en ámbar es increíble.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Luis Cabrera", Comentario = "El ámbar dominicano es único en el mundo. Una visita obligatoria en Puerto Plata.", Calificacion = 4, Fecha = "Febrero 2026" }
                    }
                },
                new TurismoCultural
                {
                    Id = 3,
                    Nombre = "Catedral San Felipe Apóstol",
                    Descripcion = "Imponente catedral de arquitectura colonial ubicada en el corazón del Parque Central de Puerto Plata. Símbolo religioso e histórico de la ciudad.",
                    Imagen = "images/cultural/catedral.jpg",
                    Ubicacion = "Parque Central, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Catedral+San+Felipe+Apostol+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Iglesia",
                    Horario = "8:00am - 6:00pm",
                    PrecioEntrada = "Gratis",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "María Luisa Pérez", Comentario = "Arquitectura colonial hermosa. Un lugar de paz y serenidad en el corazón de la ciudad.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Jorge Hernández", Comentario = "Impresionante catedral con una historia rica. Vale la pena visitarla.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new TurismoCultural
                {
                    Id = 4,
                    Nombre = "Parque Central de Puerto Plata",
                    Descripcion = "El corazón histórico de la ciudad con su famosa glorieta victoriana, rodeado de edificios coloniales, árboles centenarios y vida cultural dominicana.",
                    Imagen = "images/cultural/parque-central.jpg",
                    Ubicacion = "Centro Histórico, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Parque+Central+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Monumento",
                    Horario = "Abierto todo el día",
                    PrecioEntrada = "Gratis",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Alicia Domínguez", Comentario = "El corazón de Puerto Plata. La glorieta victoriana es única en el Caribe.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Rafael Guerrero", Comentario = "Hermoso parque con mucha historia. Perfecto para caminar y conocer la cultura local.", Calificacion = 4, Fecha = "Febrero 2026" }
                    }
                },
                new TurismoCultural
                {
                    Id = 5,
                    Nombre = "Museo de Arte Taíno",
                    Descripcion = "Colección de artefactos y piezas arqueológicas de la cultura taína, los habitantes originales de la isla.",
                    Imagen = "images/cultural/museo-taino.jpg",
                    Ubicacion = "Puerto Plata Centro",
                    GoogleMapsUrl = "https://maps.google.com/?q=Museo+Taino+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Museo",
                    Horario = "9:00am - 5:00pm",
                    PrecioEntrada = "RD$150",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Beatriz Santana", Comentario = "Una ventana fascinante a la cultura precolombina. Las piezas taínas son extraordinarias.", Calificacion = 5, Fecha = "Febrero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Ernesto Familia", Comentario = "Muy educativo e interesante. Aprendí mucho sobre los taínos y su cultura.", Calificacion = 4, Fecha = "Enero 2026" }
                    }
                },
                new TurismoCultural
                {
                    Id = 6,
                    Nombre = "Casa de la Cultura de Puerto Plata",
                    Descripcion = "Centro cultural que alberga exposiciones de arte local, eventos musicales, teatro y talleres artísticos.",
                    Imagen = "images/cultural/casa-cultura.jpg",
                    Ubicacion = "Puerto Plata Centro",
                    GoogleMapsUrl = "https://maps.google.com/?q=Casa+de+la+Cultura+Puerto+Plata",
                    SitioWeb = "#",
                    TipoLugar = "Centro Cultural",
                    Horario = "9:00am - 6:00pm",
                    PrecioEntrada = "Gratis",
                    Resenas = new List<Resena>
                    {
                        new Resena { Id = 1, NombreVisitante = "Natalia Ramos", Comentario = "Un espacio vibrante lleno de arte y cultura dominicana. Los eventos son increíbles.", Calificacion = 5, Fecha = "Enero 2026" },
                        new Resena { Id = 2, NombreVisitante = "Héctor Ureña", Comentario = "Excelente lugar para conocer el talento artístico local. Las exposiciones son muy buenas.", Calificacion = 4, Fecha = "Febrero 2026" }
                    }
                }
            };
        }

        public TurismoCultural? GetLugar(int id) =>
            GetLugares().FirstOrDefault(l => l.Id == id);
    }
}