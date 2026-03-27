using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using RutaRD.Core.Models;

namespace RutaRD.Api.Data
{
    public static class DataSeeder
    {
        public static void Seed(RutaRDbContext context)
        {
            // Verificar si ya existe el admin por defecto
            if (context.Usuarios.Any(u => u.Correo == "admin@rutard.com"))
            {
                return; // Ya fue seedeado
            }

            // Crear usuario admin por defecto
            var admin = new Usuario
            {
                Nombre = "Administrador",
                Correo = "admin@rutard.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Rol = "Administrador",
                FechaRegistro = DateTime.UtcNow
            };

            context.Usuarios.Add(admin);
            context.SaveChanges();

            Console.WriteLine("✓ Usuario admin creado: admin@rutard.com / Admin123!");
        }
    }
}
