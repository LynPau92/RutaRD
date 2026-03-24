# RutaRD - Documentación del Proyecto

## Información General

**Nombre del Proyecto:** RutaRD
**Tipo:** Aplicación Web de Turismo
**Ubicación:** /home/Yasmany/RiderProjects/RutaRD
**Tecnología:** Blazor WebAssembly (ASP.NET Core 10.0)
**Propósito:** Guía de turismo local para Puerto Plata, República Dominicana

## Estructura del Proyecto

```
RutaRD/
├── App.razor                    # Router principal
├── Program.cs                   # Configuración de servicios
├── Frontend.csproj             # Proyecto Blazor WebAssembly
├── Layout/                     # Componentes de layout
│   ├── MainLayout.razor       # Layout principal con autenticación
│   └── NavMenu.razor          # Menú de navegación
├── Pages/                      # Páginas de la aplicación
│   ├── Home.razor             # Página principal con buscador
│   ├── Login.razor            # Autenticación
│   ├── Configuracion.razor    # Configuración de usuario
│   ├── Reservar.razor         # Reservas de hoteles
│   ├── Hoteles.razor          # Listado de hoteles
│   ├── HotelDetalle.razor     # Detalle de hotel
│   ├── Restaurantes.razor     # Listado de restaurantes
│   ├── RestauranteDetalle.razor
│   ├── Turismo-cultural.razor
│   ├── TurismoCulturalDetalle.razor
│   ├── Turismo-ecologico.razor
│   ├── TurismoEcologicoDetalle.razor
│   ├── Eventos-actividades.razor
│   ├── EventosActividadesDetalle.razor
│   └── NotFound.razor         # Página 404
├── Shared/                     # Componentes compartidos
│   ├── ChatBot.razor          # Chatbot con IA (Claude)
│   ├── BuscadorGeneral.razor  # Buscador genérico
│   └── BuscadorReservas.razor # Buscador de reservas
├── Services/                   # Lógica de negocio
│   ├── AuthService.cs         # Autenticación y usuarios
│   ├── HotelService.cs        # Datos de hoteles
│   ├── RestauranteService.cs  # Datos de restaurantes
│   ├── TurismoEcologicoService.cs
│   ├── TurismoCulturalService.cs
│   └── EventosActividadesService.cs
├── Models/                     # Modelos de datos
│   ├── Hotel.cs
│   ├── Restaurante.cs
│   ├── TurismoEcologico.cs
│   ├── TurismoCultural.cs
│   ├── EventosActividades.cs
│   ├── Reserva.cs
│   ├── Resena.cs
│   └── tablas.md              # Documentación de base de datos
├── wwwroot/                    # Archivos estáticos
│   ├── index.html
│   ├── css/
│   │   └── app.css            # Estilos globales
│   └── images/                # Imágenes organizadas por categoría
│       ├── hoteles/
│       ├── restaurantes/
│       ├── cultural/
│       ├── ecologico/
│       └── eventos/
└── _Imports.razor             # Imports globales
```

## Arquitectura y Patrones

### Framework y Versiones
- **.NET:** 10.0
- **Blazor:** WebAssembly
- **Bootstrap:** 5.x (CDN)
- **Nullable:** enable
- **ImplicitUsings:** enable

### Servicios Inyectados (Program.cs:6-18)
```csharp
- HttpClient (BaseAddress dinámica)
- HotelService
- RestauranteService
- TurismoEcologicoService
- EventosActividadesService
- TurismoCulturalService
- AuthService
```

### Sistema de Autenticación
- **Tipo:** Autenticación simple con localStorage
- **Roles:** Cliente, Administrador
- **Almacenamiento:** localStorage del navegador
- **Credenciales por defecto:**
  - Admin: admin@rutard.com / Admin123

### Datos del Sistema
Los datos están **hardcodeados** en los Services:
- **Hoteles:** 6 hoteles en Playa Dorada (HotelService.cs:9-131)
- **Restaurantes:** Varios restaurantes con diferentes rangos de precios
- **Turismo Ecológico:** Playas, montañas, ríos, senderos
- **Turismo Cultural:** Museos, fortalezas, iglesias, monumentos
- **Eventos:** Festivales y actividades locales

## Funcionalidades Principales

### 1. Home (Home.razor:1-156)
- Buscador principal por categoría
- Sistema de reservas de hoteles con:
  - Selección de fechas (check-in/check-out)
  - Contador de adultos, niños y habitaciones
  - Validación de fechas

### 2. ChatBot (Shared/ChatBot.razor:1-139)
- **Nombre:** RutaBot
- **API:** Claude AI (claude-sonnet-4-20250514)
- **Función:** Asistente virtual de turismo
- **Configuración:** Requiere `ClaudeApiKey` en configuración
- **Prompt del sistema:** Conocimientos específicos de Puerto Plata

### 3. Autenticación (Services/AuthService.cs:1-115)
- Login con correo/contraseña
- Registro de nuevos usuarios
- Persistencia con localStorage
- Eventos de cambio de estado

### 4. Layout (Layout/MainLayout.razor:1-83)
- Muestra NavMenu solo si está autenticado
- Footer con información de contacto
- Redes sociales (Facebook, Instagram, YouTube, TikTok)
- ChatBot integrado

## Estructura de Base de Datos (Reference)

Ver documentación completa en `Models/tablas.md:1-64`

### Tablas Principales:
1. **Usuarios** - Autenticación y roles
2. **Hoteles** - Información de alojamiento
3. **HotelServicios** - Relación many-to-many
4. **Restaurantes** - Gastronomía local
5. **TurismoEcologico** - Naturaleza y aventura
6. **TurismoCultural** - Patrimonio cultural
7. **EventosActividades** - Eventos y festivales
8. **Resenas** - Reseñas polimórficas
9. **Reservas** - Sistema de reservas

## Imágenes del Sistema

### Hoteles (wwwroot/images/hoteles/)
- casa-colonial.png - Casa Colonial Beach & Spa (5★)
- iberostar.png - Iberostar Costa Dorada (5★)
- bluebay.png - BlueBay Villas Doradas (4★)
- emotions.png - Emotions by Hodelpa (4★)
- vh.png - VH Gran Ventana Beach Resort (4★)
- sunscape.png - Sunscape Puerto Plata (4★)

### Directorios de imágenes:
- `/images/hoteles/` - Alojamiento
- `/images/restaurantes/` - Gastronomía
- `/images/cultural/` - Turismo cultural
- `/images/ecologico/` - Turismo ecológico
- `/images/eventos/` - Eventos y actividades

## Rutas de Navegación

```
/ → Home (redirige a Login si no autenticado)
/Login → Autenticación
/Hoteles → Listado de hoteles
/HotelDetalle?id={id} → Detalle de hotel
/Restaurantes → Listado de restaurantes
/RestauranteDetalle?id={id} → Detalle de restaurante
/Turismo-cultural → Turismo cultural
/TurismoCulturalDetalle?id={id} → Detalle cultural
/Turismo-ecologico → Turismo ecológico
/TurismoEcologicoDetalle?id={id} → Detalle ecológico
/Eventos-actividades → Eventos y actividades
/EventosActividadesDetalle?id={id} → Detalle de evento
/Reservar?HotelId={id}&FechaEntrada={fecha}&... → Formulario de reserva
/Configuracion → Configuración de usuario
```

## Características Especiales

### ChatBot IA (ChatBot.razor)
- API de Anthropic Claude
- Contexto específico de Puerto Plata
- Recomendaciones personalizadas
- Soporte para hoteles, restaurantes, actividades, cultura

### Sistema de Reservas
- Cálculo automático de noches
- Validación de fechas
- Soporte para adultos, niños y habitaciones
- Generación de presupuestos

### Estilos
- Bootstrap 5 (CDN)
- CSS personalizado por componente
- Sistema de responsive design
- Colores corporativos: Azul (#1b6ec2), etc.

## Configuración Requerida

### appsettings.json (necesario para ChatBot)
```json
{
  "ClaudeApiKey": "tu-api-key-aqui"
}
```

### Usuarios por Defecto
- **Administrador:** admin@rutard.com / Admin123

## Comandos Útiles

### Ejecutar proyecto
```bash
dotnet run
```

### Construir para producción
```bash
dotnet build -c Release
```

### Publicar
```bash
dotnet publish -c Release
```

## Notas Importantes

1. **Datos Mock:** Todos los datos están hardcodeados en los Services
2. **IA Integration:** El ChatBot requiere API key de Anthropic
3. **Persistencia:** Usa localStorage para sesiones
4. **Imágenes:** Rutas relativas a wwwroot/images/
5. **Autenticación:** Simple, sin backend real (solo demo)
6. **Layout:** Solo visible tras autenticación

## Estado Actual del Proyecto

Últimos commits (git log):
- adc04dd - Cambios en turismo cultural y ecológico
- 552aa2c - Creación del login y cambios en módulo de configuración
- 50d1209 - Colocación de reservas en páginas no funcionales
- 3c7ce79 - Cambios en páginas de hoteles, reservas y en app.css
- 8dd50f8 - Cambios en página hoteles

Branch: main

## Próximos Pasos Sugeridos

1. **Backend Real:** Conectar a API real para datos dinámicos
2. **Base de Datos:** Implementar SQL Server/PostgreSQL según tablas.md
3. **Autenticación:** Integrar IdentityServer o ASP.NET Identity
4. **Pagos:** Integrar pasarela de pago para reservas
5. **Mapas:** Integrar Google Maps API para ubicaciones
6. **Multimedia:** Agregar galería de imágenes y videos
7. **Reviews:** Sistema de reseñas funcional
8. **Admin Panel:** Panel de administración para gestionar contenido

## Contacto del Proyecto

- **Ubicación:** Puerto Plata, República Dominicana
- **Teléfono:** +1 (809) 789-4512
- **Correo:** info@rutard.com
- **Horario:** Lun - Vie: 8:00am - 5:00pm

---

**Última actualización:** 2026-03-23
**Versión:** 1.0.0
**Generado para:** Documentación de futuras sesiones de desarrollo
