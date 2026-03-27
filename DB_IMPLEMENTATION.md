# Guía de Implementación de Base de Datos - RutaRD

## 📋 Resumen de Implementación

Esta guía documenta la implementación de persistencia de datos con **PostgreSQL** y **Entity Framework Core** para el proyecto RutaRD.

## 🏗️ Arquitectura Implementada

```
RutaRD/
├── Frontend.csproj           # Blazor WebAssembly (existente)
├── RutaRD.Core/               # Modelos compartidos (NUEVO)
│   ├── Models/                # Entidades EF Core
│   │   ├── Usuario.cs
│   │   ├── Hotel.cs
│   │   ├── HotelServicio.cs
│   │   ├── Restaurante.cs
│   │   ├── TurismoEcologico.cs
│   │   ├── TurismoCultural.cs
│   │   ├── EventosActividades.cs
│   │   ├── Resena.cs
│   │   └── Reserva.cs
│   └── RutaRD.Core.csproj
└── RutaRD.Api/                # Web API Backend (NUEVO)
    ├── Controllers/           # API Controllers
    │   └── HotelesController.cs
    ├── Data/
    │   └── RutaRDbContext.cs  # DbContext
    ├── Program.cs             # Configuración
    ├── appsettings.json       # Connection strings
    └── RutaRD.Api.csproj
```

## 📦 Archivos Creados

### 1. Proyecto RutaRD.Core (Modelos Compartidos)
- ✅ `RutaRD.Core.csproj` - Proyecto de clase
- ✅ `Models/Usuario.cs` - Usuario con autenticación
- ✅ `Models/Hotel.cs` - Hotel con relaciones
- ✅ `Models/HotelServicio.cs` - Tabla many-to-many
- ✅ `Models/Restaurante.cs` - Restaurantes
- ✅ `Models/TurismoEcologico.cs` - Turismo ecológico
- ✅ `Models/TurismoCultural.cs` - Turismo cultural
- ✅ `Models/EventosActividades.cs` - Eventos
- ✅ `Models/Resena.cs` - Reseñas polimórficas
- ✅ `Models/Reserva.cs` - Reservas completas

### 2. Proyecto RutaRD.Api (Backend API)
- ✅ `RutaRD.Api.csproj` - Configuración con EF Core y PostgreSQL
- ✅ `Data/RutaRDbContext.cs` - DbContext con todas las entidades
- ✅ `Controllers/HotelesController.cs` - API REST de hoteles
- ✅ `Program.cs` - Configuración de servicios y middleware
- ✅ `appsettings.json` - Connection strings (producción)
- ✅ `appsettings.Development.json` - Connection strings (desarrollo)

## 🔧 Configuración de PostgreSQL

### Instalar PostgreSQL

**Linux (Debian/Ubuntu):**
```bash
sudo apt update
sudo apt install postgresql postgresql-contrib
sudo systemctl start postgresql
sudo systemctl enable postgresql
```

**Verificar instalación:**
```bash
sudo -u postgres psql --version
```

### Crear Base de Datos

```bash
# Acceder a PostgreSQL
sudo -u postgres psql

# Crear usuario y base de datos
CREATE USER rutard WITH PASSWORD 'RutaRD2026!';
CREATE DATABASE rutard OWNER rutard;
GRANT ALL PRIVILEGES ON DATABASE rutard TO rutard;
\q

# Verificar conexión
psql -h localhost -U rutard -d rutard
```

### Actualizar Connection String

Editar `RutaRD.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=rutard;Username=rutard;Password=RutaRD2026!"
  }
}
```

## 🚀 Instalación y Ejecución

### 1. Instalar Herramientas de .NET

```bash
# Verificar instalación de .NET
dotnet --version

# Si no está instalado, instalar .NET 10 SDK
# (Descargar desde https://dotnet.microsoft.com/download)
```

### 2. Restaurar Paquetes NuGet

```bash
cd /home/Yasmany/RiderProjects/RutaRD/RutaRD.Api
dotnet restore
```

### 3. Crear Migraciones Iniciales

```bash
cd /home/Yasmany/RiderProjects/RutaRD/RutaRD.Api

# Instalar herramientas EF si no están instaladas
dotnet tool install --global dotnet-ef

# Crear migración inicial
dotnet ef migrations add InitialCreate --project ../RutaRD.Core --startup-project .

# Aplicar migración
dotnet ef database update --project ../RutaRD.Core --startup-project .
```

### 4. Ejecutar la API

```bash
cd /home/Yasmany/RiderProjects/RutaRD/RutaRD.Api

# Modo desarrollo
dotnet run

# Modo producción
dotnet run --environment Production
```

La API estará disponible en:
- **HTTP:** http://localhost:5193
- **HTTPS:** https://localhost:7121
- **Swagger:** http://localhost:5193 (raíz)

### 5. Verificar Funcionamiento

```bash
# Probar API de hoteles
curl http://localhost:5193/api/Hoteles

# Probar Swagger UI
# Abrir navegador en http://localhost:5193
```

## 📊 Endpoints de la API

### Hoteles

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Hoteles` | Obtener todos los hoteles |
| GET | `/api/Hoteles/{id}` | Obtener hotel por ID |
| POST | `/api/Hoteles` | Crear nuevo hotel |
| PUT | `/api/Hoteles/{id}` | Actualizar hotel |
| DELETE | `/api/Hoteles/{id}` | Eliminar hotel |
| GET | `/api/Hoteles/filter` | Filtrar hoteles (query params) |

**Filtros disponibles:**
- `estrellas` (int): Filtrar por número de estrellas
- `tipo` (string): Resort, Boutique, Todo Incluido
- `precioMin` (decimal): Precio mínimo
- `precioMax` (decimal): Precio máximo
- `servicio` (string): Piscina, Spa, Playa Privada, etc.

### Ejemplos de Uso

```bash
# Obtener todos los hoteles
curl http://localhost:5193/api/Hoteles

# Obtener hotel por ID
curl http://localhost:5193/api/Hoteles/1

# Filtrar hoteles de 4 estrellas
curl "http://localhost:5193/api/Hoteles/filter?estrellas=4"

# Filtrar resorts con precio entre 5000 y 8000
curl "http://localhost:5193/api/Hoteles/filter?tipo=Resort&precioMin=5000&precioMax=8000"

# Filtrar hoteles con piscina
curl "http://localhost:5193/api/Hoteles/filter?servicio=Piscina"
```

## 🌱 Seed Data (Datos Iniciales)

Crear archivo `RutaRD.Api/Data/DbInitializer.cs`:

```csharp
using RutaRD.Core.Models;

namespace RutaRD.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RutaRDbContext context)
        {
            context.Database.EnsureCreated();

            // Verificar si ya hay datos
            if (context.Hoteles.Any())
            {
                return; // DB ya tiene datos
            }

            // Agregar hoteles
            var hoteles = new List<Hotel>
            {
                new Hotel
                {
                    Nombre = "Casa Colonial Beach & Spa",
                    Descripcion = "Hotel boutique de lujo frente a la playa en Playa Dorada",
                    Imagen = "images/hoteles/casa-colonial.png",
                    Ubicacion = "Playa Dorada, Puerto Plata",
                    GoogleMapsUrl = "https://maps.google.com/?q=Casa+Colonial+Beach+Spa+Puerto+Plata",
                    Estrellas = 5,
                    PrecioNoche = 8500.00m,
                    Telefono = "+1 (809) 320-3232",
                    SitioWeb = "https://www.casacolonialhotel.com",
                    Tipo = "Boutique",
                    FechaCreacion = DateTime.Now,
                    HotelServicios = new List<HotelServicio>
                    {
                        new HotelServicio { Servicio = "Piscina Infinity" },
                        new HotelServicio { Servicio = "Spa" },
                        new HotelServicio { Servicio = "Restaurante Gourmet" },
                        new HotelServicio { Servicio = "Playa privada" },
                        new HotelServicio { Servicio = "Gimnasio" },
                        new HotelServicio { Servicio = "WiFi" }
                    }
                },
                // ... más hoteles
            };

            context.Hoteles.AddRange(hoteles);
            context.SaveChanges();

            // Agregar usuario administrador por defecto
            var admin = new Usuario
            {
                Nombre = "Administrador",
                Correo = "admin@rutard.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                Rol = "Administrador",
                FechaRegistro = DateTime.Now
            };

            context.Usuarios.Add(admin);
            context.SaveChanges();

            Console.WriteLine("✓ Base de datos sembrada con datos iniciales");
        }
    }
}
```

## 🔄 Actualizar Frontend para usar API

### Modificar `Frontend/Services/HotelService.cs`

```csharp
public class HotelService
{
    private readonly HttpClient _http;

    public HotelService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("http://localhost:5193/api/");
    }

    public async Task<List<Hotel>> GetHoteles()
    {
        var hoteles = await _http.GetFromJsonAsync<List<Hotel>>("Hoteles");
        return hoteles ?? new List<Hotel>();
    }

    public async Task<Hotel?> GetHotel(int id)
    {
        var hotel = await _http.GetFromJsonAsync<Hotel>($"Hoteles/{id}");
        return hotel;
    }
}
```

## 🧪 Testing de la API

### Usar Swagger UI

1. Ejecutar la API: `dotnet run`
2. Abrir navegador: `http://localhost:5193`
3. Probar endpoints desde Swagger

### Usar cURL

```bash
# GET todos los hoteles
curl -X GET "http://localhost:5193/api/Hoteles" \
  -H "accept: application/json"

# GET hotel por ID
curl -X GET "http://localhost:5193/api/Hoteles/1" \
  -H "accept: application/json"

# POST nuevo hotel
curl -X POST "http://localhost:5193/api/Hoteles" \
  -H "accept: application/json" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Nuevo Hotel",
    "descripcion": "Hotel de prueba",
    "ubicacion": "Puerto Plata",
    "estrellas": 4,
    "precioNoche": 5000.00,
    "tipo": "Resort"
  }'
```

## 🔒 Seguridad

### Autenticación JWT (Próxima implementación)

```csharp
// En Program.cs
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => { ... });

// En Controllers
[Authorize]
public class ProtectedController : ControllerBase
{
    // ...
}
```

## 🐛 Solución de Problemas

### Error: "No se puede conectar al servidor PostgreSQL"

**Solución:**
```bash
# Verificar que PostgreSQL está corriendo
sudo systemctl status postgresql

# Verificar conexión
psql -h localhost -U rutard -d rutard

# Revisar logs de PostgreSQL
sudo tail -f /var/log/postgresql/postgresql-14-main.log
```

### Error: "dotnet ef command not found"

**Solución:**
```bash
dotnet tool install --global dotnet-ef
export PATH="$PATH:$HOME/.dotnet/tools"
```

### Error: "Cannot find project file"

**Solución:**
```bash
# Asegurarse de estar en el directorio correcto
cd /home/Yasmany/RiderProjects/RutaRD/RutaRD.Api

# Especificar rutas correctamente
dotnet ef migrations add InitialCreate \
  --project /home/Yasmany/RiderProjects/RutaRD/RutaRD.Core \
  --startup-project /home/Yasmany/RiderProjects/RutaRD/RutaRD.Api
```

## 📝 Próximos Pasos

### Pendientes de Implementación

1. **Completar API Controllers:**
   - [ ] RestaurantesController
   - [ ] TurismoEcologicoController
   - [ ] TurismoCulturalController
   - [ ] EventosActividadesController
   - [ ] ReservasController
   - [ ] UsuariosController (con autenticación)
   - [ ] ResenasController

2. **Implementar Seed Data Completo:**
   - [ ] Migrar todos los datos hardcoded a DB
   - [ ] Crear script de sembrado
   - [ ] Ejecutar seed en primera ejecución

3. **Actualizar Frontend:**
   - [ ] Modificar todos los Services para usar HttpClient
   - [ ] Remover datos hardcoded
   - [ ] Implementar manejo de errores HTTP
   - [ ] Agregar loading states

4. **Seguridad:**
   - [ ] Implementar autenticación JWT
   - [ ] Agregar autorización por roles
   - [ ] Implementar refresh tokens
   - [ ] Hash de contraseñas con BCrypt

5. **Testing:**
   - [ ] Tests unitarios de Controllers
   - [ ] Tests de integración de DB
   - [ ] Tests de carga

## 📞 Soporte

**Documentación relacionada:**
- `PROJECT_INFO.md` - Información general del proyecto
- `Models/tablas.md` - Esquema de base de datos
- `UX_IMPROVEMENTS.md` - Mejoras de UX pendientes

**Recursos:**
- Entity Framework Core: https://docs.microsoft.com/ef/core/
- Npgsql (PostgreSQL): https://www.npgsql.org/efcore/
- ASP.NET Core API: https://docs.microsoft.com/aspnet/core/web-api/

---

**Última actualización:** 2026-03-23
**Versión:** 1.0
**Estado:** Implementación inicial completada
