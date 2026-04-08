using System.Net.Http.Json;
using System.Text.Json;
using Frontend.Models;

namespace Frontend.Services
{
    public class HotelService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://localhost:5000/api/hoteles";

        public HotelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Hotel>> GetHoteles()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al obtener hoteles: {response.StatusCode}");
                    return new List<Hotel>();
                }

                var json = await response.Content.ReadAsStringAsync();
                var backendHoteles = JsonSerializer.Deserialize<List<BackendHotel>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Convertir los datos del backend al formato del frontend
                return ConvertirHotelesToFrontend(backendHoteles ?? new List<BackendHotel>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener hoteles: {ex.Message}");
                return new List<Hotel>();
            }
        }

        public async Task<Hotel?> GetHotel(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al obtener hotel {id}: {response.StatusCode}");
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var backendHotel = JsonSerializer.Deserialize<BackendHotel>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return backendHotel != null ? ConvertirHotelToFrontend(backendHotel) : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener hotel {id}: {ex.Message}");
                return null;
            }
        }

        private List<Hotel> ConvertirHotelesToFrontend(List<BackendHotel> hotelesBackend)
        {
            return hotelesBackend.Select(ConvertirHotelToFrontend).ToList();
        }

        private Hotel ConvertirHotelToFrontend(BackendHotel backendHotel)
        {
            // Crear el modelo del frontend
            return new Hotel
            {
                Id = backendHotel.Id,
                Nombre = backendHotel.Nombre,
                Descripcion = backendHotel.Descripcion,
                Imagen = backendHotel.Imagen,
                Ubicacion = backendHotel.Ubicacion,
                GoogleMapsUrl = backendHotel.GoogleMapsUrl,
                Estrellas = backendHotel.Estrellas,
                PrecioNoche = backendHotel.PrecioNoche,
                Telefono = backendHotel.Telefono,
                SitioWeb = backendHotel.SitioWeb,
                Tipo = backendHotel.Tipo,
                HotelServicios = backendHotel.HotelServicios?.Select(hs => new HotelServicio
                {
                    Id = hs.Id,
                    HotelId = hs.HotelId,
                    Servicio = hs.Servicio
                }).ToList(),
                ResenasBackend = backendHotel.Resenas?.Select(r => new Resena
                {
                    Id = r.Id,
                    NombreVisitante = r.NombreVisitante,
                    Comentario = r.Comentario,
                    Calificacion = r.Calificacion,
                    Fecha = r.Fecha.ToString("MMMM yyyy")
                }).ToList()
            };
        }
    }

    // Modelos backend para deserialización
    public class BackendHotel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public string? Ubicacion { get; set; }
        public string? GoogleMapsUrl { get; set; }
        public double Estrellas { get; set; }
        public decimal PrecioNoche { get; set; }
        public string? Telefono { get; set; }
        public string? SitioWeb { get; set; }
        public string? Tipo { get; set; }
        public List<BackendHotelServicio>? HotelServicios { get; set; }
        public List<BackendResena>? Resenas { get; set; }
    }

    public class BackendHotelServicio
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Servicio { get; set; } = "";
    }

    public class BackendResena
    {
        public int Id { get; set; }
        public string NombreVisitante { get; set; } = "";
        public string? Comentario { get; set; }
        public double Calificacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}