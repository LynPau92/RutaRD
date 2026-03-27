using Microsoft.EntityFrameworkCore;
using RutaRD.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure PostgreSQL
builder.Services.AddDbContext<RutaRDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Crear base de datos y aplicar migraciones automáticamente en desarrollo
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<RutaRDbContext>();
        try
        {
            // Asegurar que la base de datos existe
            context.Database.EnsureCreated();

            Console.WriteLine("✓ Base de datos creada/verificada exitosamente");

            // Ejecutar seed de datos SIEMPRE (verifica internamente si ya existe)
            DataSeeder.Seed(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error al crear base de datos: {ex.Message}");
        }
    }
}

app.Run();
