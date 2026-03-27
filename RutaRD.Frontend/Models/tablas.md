# Esquema de Base de Datos - RutaRD

## Documentación de Tablas SQL

Este documento describe el esquema de base de datos para el sistema RutaRD. Los modelos C# actuales están implementados en el frontend, pero esta documentación sirve como referencia para una futura implementación de backend.

---

## Tabla: Usuarios

Almacena todos los usuarios del sistema.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `Nombre` (varchar 100, NOT NULL)
- `Correo` (varchar 150, UNIQUE, NOT NULL)
- `Contrasena` (varchar 255, NOT NULL) - almacenada como hash BCrypt
- `Rol` (varchar 20, NOT NULL) - valores: 'Cliente', 'Administrador'
- `FechaRegistro` (datetime, DEFAULT GETDATE())

**Nota:** Actualmente implementado en `AuthService.cs` con almacenamiento en localStorage del navegador.

---

## Tabla: Hoteles

Almacena información de establecimientos hoteleros.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `Nombre` (varchar 150, NOT NULL)
- `Descripcion` (text)
- `Imagen` (varchar 300)
- `Ubicacion` (varchar 200)
- `GoogleMapsUrl` (varchar 500)
- `Estrellas` (decimal 2,1)
- `PrecioNoche` (decimal 10,2)
- `Telefono` (varchar 20)
- `SitioWeb` (varchar 300)
- `Tipo` (varchar 50) - Resort, Boutique, Todo Incluido
- `FechaCreacion` (datetime, DEFAULT GETDATE())

**Nota:** El modelo C# incluye propiedades de navegación:
- `List<Resena> Resenas` - Reseñas del hotel
- `List<string> Servicios` - Lista de servicios (Piscina, Spa, etc.)

---

## Tabla: HotelServicios

Relación many-to-many entre hoteles y sus servicios.

**Columnas:**
- `Id` (int, PK)
- `HotelId` (int, FK → Hoteles.Id)
- `Servicio` (varchar 100) - Piscina, Spa, Playa Privada, Restaurante, etc.

**Nota:** Actualmente implementado en C# como `List<string> Servicios` dentro del modelo Hotel, no como tabla separada.

---

## Tabla: Restaurantes

Almacena información de restaurantes y bares.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `Nombre` (varchar 150)
- `Descripcion` (text)
- `Imagen` (varchar 300)
- `Ubicacion` (varchar 200)
- `GoogleMapsUrl` (varchar 500)
- `Estrellas` (decimal 2,1)
- `Telefono` (varchar 20)
- `SitioWeb` (varchar 300)
- `RangoPrecios` (varchar 10) - $, $$, $$$
- `OpcionVegetariana` (bit)
- `OpcionVegana` (bit)
- `FechaCreacion` (datetime)

**Nota:** El modelo C# incluye `List<Resena> Resenas`.

---

## Tabla: TurismoEcologico

Almacena información de destinos de turismo ecológico y naturaleza.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `Nombre` (varchar 150)
- `Descripcion` (text)
- `Imagen` (varchar 300)
- `Ubicacion` (varchar 200)
- `GoogleMapsUrl` (varchar 500)
- `SitioWeb` (varchar 300)
- `TipoLugar` (varchar 50) - Playa, Montaña, Río, Sendero
- `TipoActividad` (varchar 100)
- `NivelDificultad` (varchar 20) - Fácil, Moderado, Difícil
- `PrecioEntrada` (varchar 50)
- `Horario` (varchar 100)
- `FechaCreacion` (datetime)

**Nota:** El modelo C# incluye `List<Resena> Resenas`.

---

## Tabla: TurismoCultural

Almacena información de sitios de interés cultural e histórico.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `Nombre` (varchar 150)
- `Descripcion` (text)
- `Imagen` (varchar 300)
- `Ubicacion` (varchar 200)
- `GoogleMapsUrl` (varchar 500)
- `SitioWeb` (varchar 300)
- `TipoLugar` (varchar 50) - Museo, Fortaleza, Iglesia, Monumento, Centro Cultural
- `Horario` (varchar 100)
- `PrecioEntrada` (varchar 50)
- `FechaCreacion` (datetime)

**Nota:** El modelo C# incluye `List<Resena> Resenas`.

---

## Tabla: EventosActividades

Almacena información de eventos y actividades especiales.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `Nombre` (varchar 150)
- `Descripcion` (text)
- `Imagen` (varchar 300)
- `Ubicacion` (varchar 200)
- `GoogleMapsUrl` (varchar 500)
- `SitioWeb` (varchar 300)
- `Tipo` (varchar 50) - Actividad, Festival
- `Fecha` (varchar 100)
- `Horario` (varchar 100)
- `PrecioEntrada` (varchar 50)
- `FechaCreacion` (datetime)

**Nota:** El modelo C# incluye `List<Resena> Resenas`.

---

## Tabla: Resenas

Sistema de reseñas polimórfico para cualquier categoría.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `NombreVisitante` (varchar 100)
- `Comentario` (text)
- `Calificacion` (decimal 2,1)
- `Fecha` (datetime)
- `CategoriaId` (int) - ID del lugar siendo reseñado
- `CategoriaTipo` (varchar 50) - Hotel, Restaurante, TurismoEcologico, TurismoCultural, EventoActividad

**Nota Importante:** El modelo C# actual (`Models/Resena.cs`) NO incluye `CategoriaId` ni `CategoriaTipo`. Solo tiene:
- `Id`, `NombreVisitante`, `Comentario`, `Calificacion`, `Fecha`

Para implementar el sistema polimórfico descrito aquí, se debe actualizar el modelo C#.

---

## Tabla: Reservas

Almacena información de reservas de hoteles.

**Columnas:**
- `Id` (int, PK, autoincrement)
- `UsuarioId` (int, FK → Usuarios.Id)
- `HotelId` (int, FK → Hoteles.Id)
- `NombreCliente` (varchar 100)
- `Correo` (varchar 150)
- `Telefono` (varchar 20)
- `FechaEntrada` (date)
- `FechaSalida` (date)
- `Noches` (int) - calculado como DATEDIFF(day, FechaEntrada, FechaSalida)
- `Adultos` (int)
- `Ninos` (int)
- `Habitaciones` (int)
- `PrecioNoche` (decimal 10,2)
- `TotalEstimado` (decimal 10,2)
- `ITBIS` (decimal 10,2) - Impuesto
- `TotalConITBIS` (decimal 10,2)
- `SolicitudesEspeciales` (text)
- `NumeroFactura` (varchar 30)
- `FechaReserva` (datetime, DEFAULT GETDATE())
- `Estado` (varchar 20) - Pendiente, Confirmada, Cancelada

**Nota Importante:** El modelo C# actual (`Models/Reserva.cs`) está simplificado y solo incluye:
- `HotelId`, `NombreHotel`, `FechaEntrada`, `FechaSalida`, `Adultos`, `Ninos`, `Habitaciones`, `PrecioNoche`
- Propiedades computadas: `Noches`, `TotalEstimado`

Para implementar el sistema completo de reservas, se debe actualizar el modelo C# con todos los campos.

---

## Relaciones Principales

```
Reservas.UsuarioId → Usuarios.Id
Reservas.HotelId → Hoteles.Id
HotelServicios.HotelId → Hoteles.Id
Resenas.CategoriaId → ID de la tabla correspondiente según CategoriaTipo
```

---

## Diferencias entre Modelos C# y Esquema SQL

### 1. Resena
- **SQL:** Sistema polimórfico con CategoriaId y CategoriaTipo
- **C#:** Modelo simple sin categorización

### 2. Reserva
- **SQL:** Campos completos con ITBIS, Estado, UsuarioId, etc.
- **C#:** Modelo simplificado para frontend

### 3. HotelServicios
- **SQL:** Tabla many-to-many separada
- **C#:** List<string> dentro del modelo Hotel

### 4. Usuarios
- **SQL:** Tabla con todos los campos
- **C#:** Implementado en AuthService con localStorage

---

## Script de Creación de Tablas (SQL Server)

```sql
-- Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Correo VARCHAR(150) UNIQUE NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) NOT NULL CHECK (Rol IN ('Cliente', 'Administrador')),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Hoteles
CREATE TABLE Hoteles (
    Id INT PRIMARY KEY IDENTITY(1,1),
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
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- HotelServicios
CREATE TABLE HotelServicios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HotelId INT NOT NULL,
    Servicio VARCHAR(100),
    FOREIGN KEY (HotelId) REFERENCES Hoteles(Id)
);

-- Restaurantes
CREATE TABLE Restaurantes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(150),
    Descripcion TEXT,
    Imagen VARCHAR(300),
    Ubicacion VARCHAR(200),
    GoogleMapsUrl VARCHAR(500),
    Estrellas DECIMAL(2,1),
    Telefono VARCHAR(20),
    SitioWeb VARCHAR(300),
    RangoPrecios VARCHAR(10),
    OpcionVegetariana BIT,
    OpcionVegana BIT,
    FechaCreacion DATETIME
);

-- TurismoEcologico
CREATE TABLE TurismoEcologico (
    Id INT PRIMARY KEY IDENTITY(1,1),
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
);

-- TurismoCultural
CREATE TABLE TurismoCultural (
    Id INT PRIMARY KEY IDENTITY(1,1),
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
);

-- EventosActividades
CREATE TABLE EventosActividades (
    Id INT PRIMARY KEY IDENTITY(1,1),
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
);

-- Resenas
CREATE TABLE Resenas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreVisitante VARCHAR(100),
    Comentario TEXT,
    Calificacion DECIMAL(2,1),
    Fecha DATETIME,
    CategoriaId INT,
    CategoriaTipo VARCHAR(50)
);

-- Reservas
CREATE TABLE Reservas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT,
    HotelId INT,
    NombreCliente VARCHAR(100),
    Correo VARCHAR(150),
    Telefono VARCHAR(20),
    FechaEntrada DATE,
    FechaSalida DATE,
    Noches AS DATEDIFF(day, FechaEntrada, FechaSalida),
    Adultos INT,
    Ninos INT,
    Habitaciones INT,
    PrecioNoche DECIMAL(10,2),
    TotalEstimado DECIMAL(10,2),
    ITBIS DECIMAL(10,2),
    TotalConITBIS DECIMAL(10,2),
    SolicitudesEspeciales TEXT,
    NumeroFactura VARCHAR(30),
    FechaReserva DATETIME DEFAULT GETDATE(),
    Estado VARCHAR(20) CHECK (Estado IN ('Pendiente', 'Confirmada', 'Cancelada')),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (HotelId) REFERENCES Hoteles(Id)
);
```

---

**Última actualización:** 2026-03-23
**Versión:** 2.0 - Ajustada para coincidir con modelos C# existentes
