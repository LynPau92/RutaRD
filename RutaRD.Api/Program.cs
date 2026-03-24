using Microsoft.EntityFrameworkCore;
using RutaRD.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure PostgreSQL
builder.Services.AddDbContext<RutaRDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "RutaRD API",
        Version = "v1",
        Description = "API para turismo de Puerto Plata, República Dominicana",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "RutaRD",
            Email = "info@rutard.com",
            Url = new Uri("https://rutard.com")
        }
    });

    // Incluir comentarios XML (opcional)
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

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

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RutaRD API v1");
        options.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}

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
            context.Database.EnsureCreated();
            // Alternativamente: context.Database.Migrate();
            Console.WriteLine("✓ Base de datos creada/verificada exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error al crear base de datos: {ex.Message}");
        }
    }
}

app.Run();
