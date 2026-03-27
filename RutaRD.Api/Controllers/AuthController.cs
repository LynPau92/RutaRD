using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutaRD.Api.Data;
using RutaRD.Core.Models;

namespace RutaRD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RutaRDbContext _context;

        public AuthController(RutaRDbContext context)
        {
            _context = context;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<object>> Login([FromBody] LoginRequest request)
        {
            // Buscar usuario por correo
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == request.Correo);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Correo o contraseña incorrectos" });
            }

            // Verificar contraseña
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Contrasena, usuario.Contrasena);

            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Correo o contraseña incorrectos" });
            }

            // Login exitoso
            return Ok(new
            {
                message = "Login exitoso",
                usuario = new
                {
                    id = usuario.Id,
                    nombre = usuario.Nombre,
                    correo = usuario.Correo,
                    rol = usuario.Rol
                }
            });
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<object>> Register([FromBody] RegisterRequest request)
        {
            // Verificar si el correo ya existe
            if (await _context.Usuarios.AnyAsync(u => u.Correo == request.Correo))
            {
                return BadRequest(new { message = "El correo ya está registrado" });
            }

            // Hashear la contraseña
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Contrasena);

            var usuario = new Usuario
            {
                Nombre = request.Nombre,
                Correo = request.Correo,
                Contrasena = hashedPassword,
                Rol = "Cliente",
                FechaRegistro = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Usuario registrado exitosamente",
                usuario = new
                {
                    id = usuario.Id,
                    nombre = usuario.Nombre,
                    correo = usuario.Correo,
                    rol = usuario.Rol
                }
            });
        }
    }

    public class LoginRequest
    {
        public string Correo { get; set; } = "";
        public string Contrasena { get; set; } = "";
    }

    public class RegisterRequest
    {
        public string Nombre { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Contrasena { get; set; } = "";
    }
}
