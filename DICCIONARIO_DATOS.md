# Diccionario de Datos - RutaRD

## 📋 Información General

- **Nombre del Proyecto:** RutaRD - Guía de Turismo Puerto Plata
- **Motor de Base de Datos:** PostgreSQL 16+
- **ORM:** Entity Framework Core 10.0
- **Esquema:** public
- **Codificación:** UTF-8
- **Zona Horaria:** UTC (Coordinated Universal Time)

---

## 🗂️ Tablas de la Base de Datos

### 1. usuarios

Almacena la información de los usuarios del sistema, tanto clientes como administradores.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | UK | Default | Descripción |
|-------|--------------|----------|------|----|----|-----|---------|-------------|
| id | integer | - | NO | ✅ | - | - | AUTO_INCREMENT | Identificador único del usuario |
| nombre | character varying | 100 | NO | - | - | - | - | Nombre completo del usuario |
| correo | character varying | 150 | NO | - | - | ✅ | - | Correo electrónico único (índice único) |
| contrasena | character varying | 255 | NO | - | - | - | - | Contraseña hasheada con BCrypt |
| rol | character varying | 20 | NO | - | - | - | 'Cliente' | Tipo de usuario: 'Cliente' o 'Administrador' |
| fecha_registro | timestamp without time zone | - | NO | - | - | - | NOW() | Fecha y hora de registro en UTC |

**Índices:**
- `idx_usuarios_correo` - Índice UNIQUE sobre columna `correo`

**Restricciones:**
- CHECK: `rol` debe ser 'Cliente' o 'Administrador'

---

### 2. hoteles

Contiene la información de los hoteles disponibles en Puerto Plata.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único del hotel |
| nombre | character varying | 200 | NO | - | - | - | - | Nombre del hotel |
| direccion | character varying | 300 | NO | - | - | - | - | Dirección física del hotel |
| descripcion | text | - | YES | - | - | - | - | Descripción detallada del hotel |
| precio_noche | numeric | 10,2 | NO | - | - | - | - | Precio por noche en USD |
| estrellas | numeric | 2,1 | NO | - | - | - | - | Calificación del hotel (1.0 - 5.0) |
| imagen_url | character varying | 500 | YES | - | - | - | - | URL de la imagen principal |
| fecha_creacion | timestamp without time zone | - | NO | - | - | NOW() | Fecha de creación del registro |

**Relaciones:**
- Uno a muchos con `hotel_servicios`
- Uno a muchos con `reservas`
- Uno a muchos con `resenas` (polimórfico)

---

### 3. hotel_servicios

Almacena los servicios adicionales que ofrece cada hotel.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único del servicio |
| hotel_id | integer | - | NO | - | ✅ | - | FK → hoteles.id | Hotel al que pertenece el servicio |
| nombre | character varying | 100 | NO | - | - | - | - | Nombre del servicio |
| descripcion | character varying | 300 | YES | - | - | - | - | Descripción del servicio |
| cargo_extra | numeric | 10,2 | YES | - | - | - | - | Costo adicional del servicio |

**Relaciones:**
- Muchos a uno con `hoteles` (CASCADE DELETE)

---

### 4. restaurantes

Contiene información sobre restaurantes en Puerto Plata.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único del restaurante |
| nombre | character varying | 200 | NO | - | - | - | - | Nombre del restaurante |
| direccion | character varying | 300 | NO | - | - | - | - | Dirección del restaurante |
| tipo_cocina | character varying | 100 | YES | - | - | - | - | Tipo de cocina (ej: Dominicana, Italiana) |
| estrellas | numeric | 2,1 | NO | - | - | - | - | Calificación (1.0 - 5.0) |
| rango_precio | character varying | 50 | YES | - | - | - | - | Rango de precios (ej: $$, $$$) |
| horario | character varying | 100 | YES | - | - | - | - | Horario de atención |
| imagen_url | character varying | 500 | YES | - | - | - | - | URL de la imagen |
| fecha_creacion | timestamp without time zone | - | NO | - | - | NOW() | Fecha de creación del registro |

**Relaciones:**
- Uno a muchos con `resenas` (polimórfico)

---

### 5. turismo_ecologico

Almacena información sobre destinos de turismo ecológico.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único |
| nombre | character varying | 200 | NO | - | - | - | - | Nombre del destino |
| ubicacion | character varying | 300 | NO | - | - | - | - | Ubicación del destino |
| tipo_actividad | character varying | 100 | YES | - | - | - | - | Tipo de actividad (ej: Senderismo, Playa) |
| nivel_dificultad | character varying | 50 | YES | - | - | - | - | Nivel de dificultad (Fácil, Medio, Difícil) |
| precio | numeric | 10,2 | NO | - | - | - | - | Precio de la actividad |
| imagen_url | character varying | 500 | YES | - | - | - | - | URL de la imagen |
| fecha_creacion | timestamp without time zone | - | NO | - | - | NOW() | Fecha de creación del registro |

**Relaciones:**
- Uno a muchos con `resenas` (polimórfico)

---

### 6. turismo_cultural

Contiene información sobre sitios de interés cultural.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único |
| nombre | character varying | 200 | NO | - | - | - | - | Nombre del sitio |
| ubicacion | character varying | 300 | NO | - | - | - | - | Ubicación del sitio |
| tipo_sitio | character varying | 100 | YES | - | - | - | - | Tipo (Museo, Monumento, Iglesia) |
| horario_visita | character varying | 100 | YES | - | - | - | - | Horario de visitas |
| precio_entrada | numeric | 10,2 | YES | - | - | - | - | Precio de entrada |
| imagen_url | character varying | 500 | YES | - | - | - | - | URL de la imagen |
| fecha_creacion | timestamp without time zone | - | NO | - | - | NOW() | Fecha de creación del registro |

**Relaciones:**
- Uno a muchos con `resenas` (polimórfico)

---

### 7. eventos_actividades

Almacena información sobre eventos y actividades especiales.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único |
| nombre | character varying | 200 | NO | - | - | - | - | Nombre del evento |
| ubicacion | character varying | 300 | NO | - | - | - | - | Ubicación del evento |
| fecha | timestamp without time zone | - | NO | - | - | - | - | Fecha y hora del evento |
| tipo_evento | character varying | 100 | YES | - | - | - | - | Tipo de evento (Concierto, Feria, Festival) |
| precio | numeric | 10,2 | YES | - | - | - | - | Precio del evento |
| imagen_url | character varying | 500 | YES | - | - | - | - | URL de la imagen |
| fecha_creacion | timestamp without time zone | - | NO | - | - | NOW() | Fecha de creación del registro |

**Relaciones:**
- Uno a muchos con `resenas` (polimórfico)

---

### 8. resenas

Sistema polimórfico de reseñas para diferentes categorías.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único de la reseña |
| categoria_id | integer | - | NO | - | - | - | - | ID de la entidad reseñada (polimórfico) |
| categoria_tipo | character varying | 50 | NO | - | - | - | - | Tipo de entidad (Hotel, Restaurante, etc.) |
| usuario_id | integer | - | NO | - | ✅ | - | FK → usuarios.id | Usuario que escribió la reseña |
| comentario | text | - | YES | - | - | - | - | Comentario de la reseña |
| calificacion | numeric | 2,1 | NO | - | - | - | - | Calificación (1.0 - 5.0) |
| fecha_creacion | timestamp without time zone | - | YES | - | - | NOW() | Fecha de creación |

**Índices:**
- `idx_resenas_polimorfico` - Índice compuesto (categoria_id, categoria_tipo)

**Relaciones:**
- Muchos a uno con `usuarios` (RESTRICT DELETE)

**Valores de categoria_tipo:**
- 'Hotel'
- 'Restaurante'
- 'TurismoEcologico'
- 'TurismoCultural'
- 'EventosActividades'

---

### 9. reservas

Almacena las reservas de hoteles realizadas por los usuarios.

| Campo | Tipo de Dato | Longitud | Nulo | PK | FK | Default | Descripción |
|-------|--------------|----------|------|----|----|---------|-------------|
| id | integer | - | NO | ✅ | - | AUTO_INCREMENT | Identificador único de la reserva |
| usuario_id | integer | - | NO | - | ✅ | - | FK → usuarios.id | Usuario que hace la reserva |
| hotel_id | integer | - | NO | - | ✅ | - | FK → hoteles.id | Hotel reservado |
| check_in | date | - | NO | - | - | - | - | Fecha de check-in |
| check_out | date | - | NO | - | - | - | - | Fecha de check-out |
| numero_huespedes | integer | - | NO | - | - | - | - | Número de huéspedes |
| precio_noche | numeric | 10,2 | NO | - | - | - | - | Precio por noche |
| total_estimado | numeric | 10,2 | NO | - | - | - | - | Total sin impuestos |
| itbis | numeric | 10,2 | NO | - | - | - | - | ITBIS (18%) |
| total_con_itbis | numeric | 10,2 | NO | - | - | - | - | Total con impuestos |
| estado | character varying | 20 | NO | - | - | 'Pendiente' | Estado de la reserva |
| fecha_reserva | timestamp without time zone | - | NO | - | - | NOW() | Fecha de realización de la reserva |

**Relaciones:**
- Muchos a uno con `usuarios` (RESTRICT DELETE)
- Muchos a uno con `hoteles` (RESTRICT DELETE)

**Valores de estado:**
- 'Pendiente'
- 'Confirmada'
- 'Cancelada'
- 'Completada'

**Cálculo de ITBIS:**
- ITBIS = total_estimado * 0.18
- total_con_itbis = total_estimado + itbis

---

## 🔒 Seguridad y Validaciones

### Contraseñas
- **Algoritmo:** BCrypt (work factor: 10-12)
- **Longitud mínima:** 6 caracteres
- **Longitud almacenada:** 255 caracteres (hash)
- **Nunca almacenadas en texto plano**

### Correos Electrónicos
- **Validación:** Formato email estándar
- **Unicidad:** Índice UNIQUE en tabla usuarios
- **Longitud máxima:** 150 caracteres

### Roles de Usuario
| Rol | Descripción | Permisos |
|-----|-------------|----------|
| Cliente | Usuario regular | Ver catálogos, hacer reservas, dejar reseñas |
| Administrador | Gestor del sistema | CRUD completo, panel de administración |

---

## 📊 Políticas de Integridad Referencial

### CASCADE DELETE
- `hotel_servicios.hotel_id` → `hoteles.id`

### RESTRICT DELETE
- `reservas.usuario_id` → `usuarios.id`
- `reservas.hotel_id` → `hoteles.id`
- `resenas.usuario_id` → `usuarios.id`

**Justificación:** No permitir eliminar usuarios o entidades con datos asociados (reservas/reseñas)

---

## 🔄 Estados del Sistema

### Estados de Reserva
```
Pendiente → Confirmada → Completada
              ↓
          Cancelada
```

### Estados por Defecto
- Nueva reserva: 'Pendiente'
- Nuevo usuario: 'Cliente'
- Fecha de creación: NOW() (UTC)

---

## 🌐 Zona Horaria

- **Almacenamiento:** Todas las fechas en UTC
- **Visualización:** Convertir a hora local del cliente (frontend)
- **Razón:** Consistencia en aplicaciones multi-zona

---

## 📝 Notas de Implementación

### Nombres de Tablas
- Usan **snake_case** (ej: `hotel_servicios`, `turismo_ecologico`)
- Convención PostgreSQL estándar

### Nombres de Columnas
- Usan **snake_case** (ej: `precio_noche`, `fecha_creacion`)
- Compatible con EF Core + PostgreSQL

### Polimorfismo en Reseñas
- Sistema polimórfico usando `categoria_id` + `categoria_tipo`
- Permite reseñas de múltiples tipos de entidades
- Índice compuesto para optimización

### Cálculos Financieros
- **ITBIS:** 18% (República Dominicana)
- **Precios:** Almacenados en USD
- **Precisión:** DECIMAL(10,2) para todos los montos

---

## 📈 Estadísticas Esperadas

| Métrica | Estimación Inicial | Crecimiento Anual |
|---------|-------------------|-------------------|
| Usuarios | 50-100 | +300% |
| Hoteles | 20-30 | +50% |
| Restaurantes | 30-50 | +100% |
| Reservas/mes | 100-500 | +500% |
| Reseñas | 200-1000 | +400% |

---

## 🔍 Consideraciones de Performance

### Índices Recomendados
- `usuarios(correo)` - UNIQUE ✅
- `resenas(categoria_id, categoria_tipo)` - Compuesto ✅
- `reservas(usuario_id)` - Para historial de usuario
- `reservas(hotel_id)` - Para ocupación de hotel
- `reservas(fecha_reserva)` - Para reportes

### Optimizaciones Futuras
- Partitioning por fecha en `reservas`
- Caching de consultas frecuentes
- Materialized views para reportes

---

## 📚 Convenciones de Nomenclatura

### Tablas
- Plural, snake_case: `hotel_servicios`, `turismo_ecologico`

### Columnas
- snake_case: `precio_noche`, `fecha_creacion`

### Llaves Primarias
- `id` en todas las tablas

### Llaves Foráneas
- `{entidad}_id`: `usuario_id`, `hotel_id`

### Columnas de Fechas
- Sufijo `_fecha` o `_creacion`: `fecha_registro`, `fecha_creacion`

---

**Versión:** 1.0
**Última actualización:** 27 de marzo de 2026
**Maintainer:** RutaRD Development Team
