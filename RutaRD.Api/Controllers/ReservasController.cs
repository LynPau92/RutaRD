using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutaRD.Api.Data;
using RutaRD.Core.Models;

namespace RutaRD.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly RutaRDbContext _context;
        private readonly ILogger<ReservasController> _logger;

        public ReservasController(RutaRDbContext context, ILogger<ReservasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            try
            {
                var reservas = await _context.Reservas
                    .Include(r => r.Usuario)
                    .Include(r => r.Hotel)
                    .OrderByDescending(r => r.FechaReserva)
                    .ToListAsync();

                return Ok(reservas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener reservas");
                return StatusCode(500, new { message = "Error al obtener reservas", error = ex.Message });
            }
        }

        // GET: api/Reservas/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasPorUsuario(int usuarioId)
        {
            try
            {
                var reservas = await _context.Reservas
                    .Include(r => r.Hotel)
                    .Where(r => r.UsuarioId == usuarioId)
                    .OrderByDescending(r => r.FechaReserva)
                    .ToListAsync();

                return Ok(reservas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener reservas del usuario {Id}", usuarioId);
                return StatusCode(500, new { message = "Error al obtener reservas", error = ex.Message });
            }
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            try
            {
                var reserva = await _context.Reservas
                    .Include(r => r.Usuario)
                    .Include(r => r.Hotel)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (reserva == null)
                {
                    return NotFound(new { message = $"Reserva con ID {id} no encontrada" });
                }

                return Ok(reserva);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener reserva {Id}", id);
                return StatusCode(500, new { message = "Error al obtener reserva", error = ex.Message });
            }
        }

        // POST: api/Reservas
        [HttpPost]
        public async Task<ActionResult<Reserva>> CreateReserva(Reserva reserva)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verificar que el hotel existe
                var hotel = await _context.Hoteles.FindAsync(reserva.HotelId);
                if (hotel == null)
                {
                    return BadRequest(new { message = $"Hotel con ID {reserva.HotelId} no encontrado" });
                }

                // Calcular noches
                reserva.Noches = (reserva.FechaSalida - reserva.FechaEntrada).Days;

                // Calcular totales
                var subtotalPorNoche = reserva.PrecioNoche * reserva.Habitaciones;
                var subtotalAdultos = subtotalPorNoche * reserva.Adultos * reserva.Noches;
                var subtotalNinos = subtotalPorNoche * reserva.Ninos * 0.60m * reserva.Noches;
                reserva.TotalEstimado = subtotalAdultos + subtotalNinos;

                // Calcular ITBIS (18%)
                reserva.ITBIS = reserva.TotalEstimado * 0.18m;
                reserva.TotalConITBIS = reserva.TotalEstimado + reserva.ITBIS;

                // Generar número de factura
                reserva.NumeroFactura = $"RD-{DateTime.Now:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}";

                reserva.FechaReserva = DateTime.Now;
                reserva.Estado = "Pendiente";

                _context.Reservas.Add(reserva);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear reserva");
                return StatusCode(500, new { message = "Error al crear reserva", error = ex.Message });
            }
        }

        // PUT: api/Reservas/5/estado
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> UpdateEstadoReserva(int id, [FromBody] string estado)
        {
            try
            {
                var reserva = await _context.Reservas.FindAsync(id);
                if (reserva == null)
                {
                    return NotFound(new { message = $"Reserva con ID {id} no encontrada" });
                }

                if (!new[] { "Pendiente", "Confirmada", "Cancelada" }.Contains(estado))
                {
                    return BadRequest(new { message = "Estado inválido. Debe ser: Pendiente, Confirmada o Cancelada" });
                }

                reserva.Estado = estado;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar estado de reserva {Id}", id);
                return StatusCode(500, new { message = "Error al actualizar estado", error = ex.Message });
            }
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            try
            {
                var reserva = await _context.Reservas.FindAsync(id);
                if (reserva == null)
                {
                    return NotFound(new { message = $"Reserva con ID {id} no encontrada" });
                }

                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar reserva {Id}", id);
                return StatusCode(500, new { message = "Error al eliminar reserva", error = ex.Message });
            }
        }

        // GET: api/Reservas/hotel/5
        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasPorHotel(int hotelId)
        {
            try
            {
                var reservas = await _context.Reservas
                    .Include(r => r.Usuario)
                    .Where(r => r.HotelId == hotelId)
                    .OrderByDescending(r => r.FechaReserva)
                    .ToListAsync();

                return Ok(reservas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener reservas del hotel {Id}", hotelId);
                return StatusCode(500, new { message = "Error al obtener reservas", error = ex.Message });
            }
        }
    }
}
