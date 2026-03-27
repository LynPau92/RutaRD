using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutaRD.Api.Data;
using RutaRD.Core.Models;

namespace RutaRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly RutaRDbContext _context;

        public AdminController(RutaRDbContext context)
        {
            _context = context;
        }

        // POST: api/admin/create
        [HttpPost("create")]
        public async Task<ActionResult<Usuario>> CreateAdmin([FromBody] CreateAdminRequest request)
        {
            // Verificar si el correo ya existe
            if (await _context.Usuarios.AnyAsync(u => u.Correo == request.Correo))
            {
                return BadRequest(new { message = "El correo ya está registrado" });
            }

            // Hashear la contraseña
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Contrasena);

            var admin = new Usuario
            {
                Nombre = request.Nombre,
                Correo = request.Correo,
                Contrasena = hashedPassword,
                Rol = "Administrador",
                FechaRegistro = DateTime.UtcNow
            };

            _context.Usuarios.Add(admin);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Administrador creado exitosamente",
                admin = new
                {
                    id = admin.Id,
                    nombre = admin.Nombre,
                    correo = admin.Correo,
                    rol = admin.Rol
                }
            });
        }

        // GET: api/admin/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<object>>> GetAdmins()
        {
            var admins = await _context.Usuarios
                .Where(u => u.Rol == "Administrador")
                .Select(u => new
                {
                    id = u.Id,
                    nombre = u.Nombre,
                    correo = u.Correo,
                    rol = u.Rol,
                    fechaRegistro = u.FechaRegistro
                })
                .ToListAsync();

            return Ok(admins);
        }
    }

    public class CreateAdminRequest
    {
        public string Nombre { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Contrasena { get; set; } = "";
    }
}
