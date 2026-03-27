using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutaRD.Api.Data;
using RutaRD.Core.Models;

namespace RutaRD.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelesController : ControllerBase
    {
        private readonly RutaRDbContext _context;
        private readonly ILogger<HotelesController> _logger;

        public HotelesController(RutaRDbContext context, ILogger<HotelesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Hoteles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHoteles()
        {
            try
            {
                var hoteles = await _context.Hoteles
                    .Include(h => h.HotelServicios)
                    .Include(h => h.Resenas)
                    .OrderBy(h => h.Nombre)
                    .ToListAsync();

                return Ok(hoteles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener hoteles");
                return StatusCode(500, new { message = "Error al obtener hoteles", error = ex.Message });
            }
        }

        // GET: api/Hoteles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            try
            {
                var hotel = await _context.Hoteles
                    .Include(h => h.HotelServicios)
                    .Include(h => h.Resenas)
                    .FirstOrDefaultAsync(h => h.Id == id);

                if (hotel == null)
                {
                    return NotFound(new { message = $"Hotel con ID {id} no encontrado" });
                }

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener hotel {Id}", id);
                return StatusCode(500, new { message = "Error al obtener hotel", error = ex.Message });
            }
        }

        // POST: api/Hoteles
        [HttpPost]
        public async Task<ActionResult<Hotel>> CreateHotel(Hotel hotel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Hoteles.Add(hotel);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear hotel");
                return StatusCode(500, new { message = "Error al crear hotel", error = ex.Message });
            }
        }

        // PUT: api/Hoteles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Hotel hotel)
        {
            try
            {
                if (id != hotel.Id)
                {
                    return BadRequest(new { message = "ID no coincide" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Entry(hotel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Hoteles.Any(e => e.Id == id))
                    {
                        return NotFound(new { message = $"Hotel con ID {id} no encontrado" });
                    }
                    throw;
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar hotel {Id}", id);
                return StatusCode(500, new { message = "Error al actualizar hotel", error = ex.Message });
            }
        }

        // DELETE: api/Hoteles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                var hotel = await _context.Hoteles.FindAsync(id);
                if (hotel == null)
                {
                    return NotFound(new { message = $"Hotel con ID {id} no encontrado" });
                }

                _context.Hoteles.Remove(hotel);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar hotel {Id}", id);
                return StatusCode(500, new { message = "Error al eliminar hotel", error = ex.Message });
            }
        }

        // GET: api/Hoteles/filter?estrellas=4&tipo=Resort&precioMin=5000&precioMax=10000
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Hotel>>> FilterHoteles(
            [FromQuery] int? estrellas,
            [FromQuery] string? tipo,
            [FromQuery] decimal? precioMin,
            [FromQuery] decimal? precioMax,
            [FromQuery] string? servicio)
        {
            try
            {
                var query = _context.Hoteles
                    .Include(h => h.HotelServicios)
                    .Include(h => h.Resenas)
                    .AsQueryable();

                if (estrellas.HasValue)
                {
                    query = query.Where(h => h.Estrellas == estrellas.Value);
                }

                if (!string.IsNullOrEmpty(tipo))
                {
                    query = query.Where(h => h.Tipo == tipo);
                }

                if (precioMin.HasValue)
                {
                    query = query.Where(h => h.PrecioNoche >= precioMin.Value);
                }

                if (precioMax.HasValue)
                {
                    query = query.Where(h => h.PrecioNoche <= precioMax.Value);
                }

                if (!string.IsNullOrEmpty(servicio))
                {
                    query = query.Where(h => h.HotelServicios.Any(hs => hs.Servicio == servicio));
                }

                var hoteles = await query.ToListAsync();

                return Ok(hoteles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al filtrar hoteles");
                return StatusCode(500, new { message = "Error al filtrar hoteles", error = ex.Message });
            }
        }
    }
}
