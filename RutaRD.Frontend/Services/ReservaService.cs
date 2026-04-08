using System.Net.Http.Json;
using System.Text.Json;
using Frontend.Models;

namespace Frontend.Services
{
    public class ReservaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://localhost:5000/api/reservas";

        public ReservaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todas las reservas de un usuario
        public async Task<(List<Reserva>? reservas, string? error)> GetReservasPorUsuarioAsync(int usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/usuario/{usuarioId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error API: {response.StatusCode} - {errorContent}");
                    return (null, $"Error al obtener reservas: {response.StatusCode}");
                }

                var reservas = await response.Content.ReadFromJsonAsync<List<Reserva>>();
                return (reservas ?? new List<Reserva>(), null);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return (null, "No se puede conectar con el servidor. Verifica que el backend esté iniciado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reservas: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
        }

        // Obtener una reserva por ID
        public async Task<Reserva?> GetReservaAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                    return null;

                var reserva = await response.Content.ReadFromJsonAsync<Reserva>();
                return reserva;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reserva {id}: {ex.Message}");
                return null;
            }
        }

        // Crear una nueva reserva
        public async Task<(Reserva? reserva, string? error)> CreateReservaAsync(Reserva reserva)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiUrl, reserva);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al crear reserva: {response.StatusCode} - {error}");
                    return (null, $"Error del servidor ({response.StatusCode}): {error}");
                }

                var reservaCreada = await response.Content.ReadFromJsonAsync<Reserva>();
                return (reservaCreada, null);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return (null, "No se puede conectar con el servidor. Verifica que el backend esté iniciado en el puerto 5000.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear reserva: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
        }

        // Actualizar estado de una reserva
        public async Task<bool> UpdateEstadoReservaAsync(int id, string estado)
        {
            try
            {
                var content = new StringContent($"\"{estado}\"", System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_apiUrl}/{id}/estado", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar estado de reserva {id}: {ex.Message}");
                return false;
            }
        }

        // Cancelar una reserva
        public async Task<bool> CancelReservaAsync(int id)
        {
            return await UpdateEstadoReservaAsync(id, "Cancelada");
        }

        // Eliminar una reserva (soft delete mediante estado)
        public async Task<bool> DeleteReservaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar reserva {id}: {ex.Message}");
                return false;
            }
        }

        // Obtener reservas activas (no canceladas) de un usuario
        public async Task<List<Reserva>> GetReservasActivasAsync(int usuarioId)
        {
            var (reservas, _) = await GetReservasPorUsuarioAsync(usuarioId);
            return reservas?.Where(r => r.Estado != "Cancelada").ToList() ?? new List<Reserva>();
        }
    }
}