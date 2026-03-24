# Alternativa: Implementación con MySQL

Si prefieres MySQL en lugar de PostgreSQL, aquí están las instrucciones.

## 🔄 Cambios Necesarios

### 1. Actualizar `RutaRD.Api.csproj`

Reemplazar:
```xml
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="10.0.0" />
```

Por:
```xml
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="10.0.0" />
```

### 2. Actualizar `Data/RutaRDbContext.cs`

Reemplazar:
```csharp
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
```

Por:
```csharp
options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
);
```

### 3. Actualizar `appsettings.json`

**PostgreSQL:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=RutaRD;Username=postgres;Password=postgres"
  }
}
```

**MySQL:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=RutaRD;User=root;Password=your_password"
  }
}
```

### 4. Cambiar `NOW()` por_CURRENT_TIMESTAMP

En `RutaRDbContext.cs`, reemplazar:
```csharp
entity.Property(e => e.FechaCreacion).HasDefaultValueSql("NOW()");
```

Por:
```csharp
entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
```

### 5. Instalar MySQL

**Linux (Debian/Ubuntu):**
```bash
sudo apt update
sudo apt install mysql-server
sudo systemctl start mysql
sudo systemctl enable mysql

# Securizar instalación
sudo mysql_secure_installation
```

**Crear base de datos:**
```bash
sudo mysql -u root -p

CREATE DATABASE rutard CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
CREATE USER 'rutard'@'localhost' IDENTIFIED BY 'RutaRD2026!';
GRANT ALL PRIVILEGES ON rutard.* TO 'rutard'@'localhost';
FLUSH PRIVILEGES;
EXIT;
```

## 📦 Script SQL Completo para MySQL

```sql
-- Crear base de datos
CREATE DATABASE IF NOT EXISTS rutard CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE rutard;

-- Tabla: Usuarios
CREATE TABLE IF NOT EXISTS Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Correo VARCHAR(150) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) NOT NULL DEFAULT 'Cliente',
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_correo (Correo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: Hoteles
CREATE TABLE IF NOT EXISTS Hoteles (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    Descripcion TEXT,
    Imagen VARCHAR(300),
    Ubicacion VARCHAR(200),
    GoogleMapsUrl VARCHAR(500),
    Estrellas DECIMAL(2,1),
    PrecioNoche DECIMAL(10,2),
    Telefono VARCHAR(20),
    SitioWeb VARCHAR(300),
    Tipo VARCHAR(50),
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: HotelServicios
CREATE TABLE IF NOT EXISTS HotelServicios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    HotelId INT NOT NULL,
    Servicio VARCHAR(100),
    FOREIGN KEY (HotelId) REFERENCES Hoteles(Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: Restaurantes
CREATE TABLE IF NOT EXISTS Restaurantes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(150),
    Descripcion TEXT,
    Imagen VARCHAR(300),
    Ubicacion VARCHAR(200),
    GoogleMapsUrl VARCHAR(500),
    Estrellas DECIMAL(2,1),
    Telefono VARCHAR(20),
    SitioWeb VARCHAR(300),
    RangoPrecios VARCHAR(10),
    OpcionVegetariana BOOLEAN DEFAULT FALSE,
    OpcionVegana BOOLEAN DEFAULT FALSE,
    FechaCreacion DATETIME
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: TurismoEcologico
CREATE TABLE IF NOT EXISTS TurismoEcologico (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(150),
    Descripcion TEXT,
    Imagen VARCHAR(300),
    Ubicacion VARCHAR(200),
    GoogleMapsUrl VARCHAR(500),
    SitioWeb VARCHAR(300),
    TipoLugar VARCHAR(50),
    TipoActividad VARCHAR(100),
    NivelDificultad VARCHAR(20),
    PrecioEntrada VARCHAR(50),
    Horario VARCHAR(100),
    FechaCreacion DATETIME
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: TurismoCultural
CREATE TABLE IF NOT EXISTS TurismoCultural (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(150),
    Descripcion TEXT,
    Imagen VARCHAR(300),
    Ubicacion VARCHAR(200),
    GoogleMapsUrl VARCHAR(500),
    SitioWeb VARCHAR(300),
    TipoLugar VARCHAR(50),
    Horario VARCHAR(100),
    PrecioEntrada VARCHAR(50),
    FechaCreacion DATETIME
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: EventosActividades
CREATE TABLE IF NOT EXISTS EventosActividades (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(150),
    Descripcion TEXT,
    Imagen VARCHAR(300),
    Ubicacion VARCHAR(200),
    GoogleMapsUrl VARCHAR(500),
    SitioWeb VARCHAR(300),
    Tipo VARCHAR(50),
    Fecha VARCHAR(100),
    Horario VARCHAR(100),
    PrecioEntrada VARCHAR(50),
    FechaCreacion DATETIME
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: Resenas
CREATE TABLE IF NOT EXISTS Resenas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreVisitante VARCHAR(100),
    Comentario TEXT,
    Calificacion DECIMAL(2,1),
    Fecha DATETIME,
    CategoriaId INT,
    CategoriaTipo VARCHAR(50),
    INDEX idx_categoria (CategoriaId, CategoriaTipo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: Reservas
CREATE TABLE IF NOT EXISTS Reservas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UsuarioId INT,
    HotelId INT,
    NombreCliente VARCHAR(100),
    Correo VARCHAR(150),
    Telefono VARCHAR(20),
    FechaEntrada DATE,
    FechaSalida DATE,
    Noches INT,
    Adultos INT,
    Ninos INT,
    Habitaciones INT,
    PrecioNoche DECIMAL(10,2),
    TotalEstimado DECIMAL(10,2),
    ITBIS DECIMAL(10,2),
    TotalConITBIS DECIMAL(10,2),
    SolicitudesEspeciales TEXT,
    NumeroFactura VARCHAR(30),
    FechaReserva DATETIME DEFAULT CURRENT_TIMESTAMP,
    Estado VARCHAR(20) DEFAULT 'Pendiente',
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE RESTRICT,
    FOREIGN KEY (HotelId) REFERENCES Hoteles(Id) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Usuario administrador por defecto
INSERT INTO Usuarios (Nombre, Correo, Contrasena, Rol) VALUES
('Administrador', 'admin@rutard.com', '$2a$11$8J5k5Z5Z5Z5Z5Z5Z5Z5Z5O', 'Administrador');
-- Nota: El hash de arriba es un ejemplo. Debes usar BCrypt para generar el hash real de "Admin123"
```

## 🔄 Migrar de PostgreSQL a MySQL

Si ya tienes PostgreSQL y quieres cambiar a MySQL:

```bash
# 1. Exportar datos de PostgreSQL
pg_dump -U rutard rutard > rutard_backup.sql

# 2. Convertir script de PostgreSQL a MySQL
# (Usar herramientas online o manualmente)

# 3. Importar a MySQL
mysql -u root -p rutard < rutard_mysql.sql
```

## 🚀 Ventajas de MySQL sobre PostgreSQL

### ✅ Ventajas de MySQL:
- Más rápido para operaciones simples de lectura
- Más extendido en hosting compartido
- Menor consumo de recursos
- Más fácil de encontrar soporte

### ❌ Desventajas de MySQL:
- Menos avanzado en funcionalidades
- Peor cumplimiento de estándares SQL
- Menos opciones en tipos de datos
- Transacciones menos robustas

## 🚀 Ventajas de PostgreSQL sobre MySQL

### ✅ Ventajas de PostgreSQL:
- Más avanzado y potente
- Mejor cumplimiento de estándares SQL
- Tipos de datos más ricos (JSON, arrays, etc.)
- Transacciones más robustas
- Mejor para consultas complejas

### ❌ Desventajas de PostgreSQL:
- Más consumo de recursos
- Más lento en operaciones simples
- Menos común en hosting compartido

## 📊 Comparación de Rendimiento

| Operación | PostgreSQL | MySQL |
|-----------|-----------|-------|
| Lecturas simples | ⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ |
| Escrituras | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐ |
| Consultas complejas | ⭐⭐⭐⭐⭐ | ⭐⭐⭐ |
| JSON/NoSQL | ⭐⭐⭐⭐⭐ | ⭐⭐⭐ |
| Uso de memoria | ⭐⭐⭐ | ⭐⭐⭐⭐ |
| Facilidad de uso | ⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ |

## 💡 Recomendación

Para este proyecto **RutaRD**, recomiendo **PostgreSQL** porque:

1. **Datos complejos:** Las reseñas polimórficas se manejan mejor
2. **Consultas avanzadas:** Filtrado múltiple (estrellas, tipo, precio, servicios)
3. **Escalabilidad:** Mejor para crecimiento futuro
4. **JSON:** Si necesitas almacenar metadata adicional
5. **Transacciones:** Más robusto para reservas críticas

Sin embargo, si prefieres **MySQL** por familiaridad o disponibilidad de hosting, funcionará perfectamente para este proyecto.

---

**Última actualización:** 2026-03-23
**Versión:** 1.0
