using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutaRD.Api.Data;
using RutaRD.Core.Models;

namespace RutaRD.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantesController : ControllerBase
    {
        private readonly RutaRDbContext _context;
        private readonly ILogger<RestaurantesController> _logger;

        public RestaurantesController(RutaRDbContext context, ILogger<RestaurantesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurantes()
        {
            try
            {
                var restaurantes = await _context.Restaurantes
                    .Include(r => r.Resenas)
                    .OrderBy(r => r.Nombre)
                    .ToListAsync();

                return Ok(restaurantes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener restaurantes");
                return StatusCode(500, new { message = "Error al obtener restaurantes", error = ex.Message });
            }
        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> GetRestaurante(int id)
        {
            try
            {
                var restaurante = await _context.Restaurantes
                    .Include(r => r.Resenas)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (restaurante == null)
                {
                    return NotFound(new { message = $"Restaurante con ID {id} no encontrado" });
                }

                return Ok(restaurante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener restaurante {Id}", id);
                return StatusCode(500, new { message = "Error al obtener restaurante", error = ex.Message });
            }
        }

        // POST: api/Restaurantes
        [HttpPost]
        public async Task<ActionResult<Restaurante>> CreateRestaurante(Restaurante restaurante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Restaurantes.Add(restaurante);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRestaurante), new { id = restaurante.Id }, restaurante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear restaurante");
                return StatusCode(500, new { message = "Error al crear restaurante", error = ex.Message });
            }
        }

        // PUT: api/Restaurantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurante(int id, Restaurante restaurante)
        {
            try
            {
                if (id != restaurante.Id)
                {
                    return BadRequest(new { message = "ID no coincide" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Entry(restaurante).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Restaurantes.Any(e => e.Id == id))
                    {
                        return NotFound(new { message = $"Restaurante con ID {id} no encontrado" });
                    }
                    throw;
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar restaurante {Id}", id);
                return StatusCode(500, new { message = "Error al actualizar restaurante", error = ex.Message });
            }
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurante(int id)
        {
            try
            {
                var restaurante = await _context.Restaurantes.FindAsync(id);
                if (restaurante == null)
                {
                    return NotFound(new { message = $"Restaurante con ID {id} no encontrado" });
                }

                _context.Restaurantes.Remove(restaurante);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar restaurante {Id}", id);
                return StatusCode(500, new { message = "Error al eliminar restaurante", error = ex.Message });
            }
        }

        // GET: api/Restaurantes/search?query=pizza
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Restaurante>>> SearchRestaurantes([FromQuery] string query)
        {
            try
            {
                var restaurantes = await _context.Restaurantes
                    .Include(r => r.Resenas)
                    .Where(r => EF.Functions.ILike(r.Nombre, $"%{query}%") ||
                                EF.Functions.ILike(r.Ubicacion!, $"%{query}%") ||
                                EF.Functions.ILike(r.Descripcion!, $"%{query}%"))
                    .OrderBy(r => r.Nombre)
                    .ToListAsync();

                return Ok(restaurantes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar restaurantes");
                return StatusCode(500, new { message = "Error al buscar restaurantes", error = ex.Message });
            }
        }
    }
}
