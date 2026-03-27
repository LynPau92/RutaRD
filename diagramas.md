# Diagramas - RutaRD

## 1. Diagrama de Base de Datos (ER)

```mermaid
erDiagram
    usuarios ||--o{ reservas : "realiza"
    usuarios {
        int Id PK
        string Nombre
        string Correo UK
        string Contrasena
        string Rol
        DateTime FechaRegistro
    }

    hoteles ||--o{ hotel_servicios : "tiene"
    hoteles ||--o{ reservas : "reservado"
    hoteles ||--o{ resenas : "evaluado"
    hoteles {
        int Id PK
        string Nombre
        string Direccion
        string Descripcion
        decimal PrecioNoche
        decimal Estrellas
        string ImagenUrl
        DateTime FechaCreacion
    }

    hotel_servicios {
        int Id PK
        int HotelId FK
        string Nombre
        string Descripcion
        string CargoExtra
    }

    restaurantes ||--o{ resenas : "evaluado"
    restaurantes {
        int Id PK
        string Nombre
        string Direccion
        string TipoCocina
        decimal Estrellas
        string RangoPrecio
        string Horario
        string ImagenUrl
        DateTime FechaCreacion
    }

    turismo_ecologico ||--o{ resenas : "evaluado"
    turismo_ecologico {
        int Id PK
        string Nombre
        string Ubicacion
        string TipoActividad
        string NivelDificultad
        decimal Precio
        string ImagenUrl
        DateTime FechaCreacion
    }

    turismo_cultural ||--o{ resenas : "evaluado"
    turismo_cultural {
        int Id PK
        string Nombre
        string Ubicacion
        string TipoSitio
        string HorarioVisita
        decimal PrecioEntrada
        string ImagenUrl
        DateTime FechaCreacion
    }

    eventos_actividades ||--o{ resenas : "evaluado"
    eventos_actividades {
        int Id PK
        string Nombre
        string Ubicacion
        DateTime Fecha
        string TipoEvento
        decimal Precio
        string ImagenUrl
        DateTime FechaCreacion
    }

    resenas {
        int Id PK
        int CategoriaId FK
        string CategoriaTipo
        int UsuarioId FK
        string Comentario
        decimal Calificacion
        DateTime FechaCreacion
    }

    reservas {
        int Id PK
        int UsuarioId FK
        int HotelId FK
        DateTime CheckIn
        DateTime CheckOut
        int NumeroHuespedes
        decimal PrecioNoche
        decimal TotalEstimado
        decimal ITBIS
        decimal TotalConITBIS
        string Estado
        DateTime FechaReserva
    }
```

## 2. Diagrama de Caso de Uso - Login

```mermaid
sequenceDiagram
    actor Usuario
    participant Frontend as Frontend Blazor
    participant API as API Backend
    participant BD as Base de Datos
    participant BCrypt as BCrypt

    Usuario->>Frontend: Ingresa credenciales<br/>(admin@rutard.com / Admin123!)
    Frontend->>Frontend: Validar campos vacíos
    Frontend->>API: POST /api/auth/login<br/>{ correo, contrasena }
    API->>BD: SELECT * FROM usuarios<br/>WHERE correo = 'admin@rutard.com'
    BD-->>API: Retorna usuario (si existe)

    alt Usuario no encontrado
        API-->>Frontend: 401 Unauthorized<br/>"Correo o contraseña incorrectos"
        Frontend-->>Usuario: Muestra error
    else Usuario encontrado
        API->>BCrypt: Verify(contrasena, hash_guardado)
        BCrypt-->>API: true/false

        alt Contraseña incorrecta
            API-->>Frontend: 401 Unauthorized<br/>"Correo o contraseña incorrectos"
            Frontend-->>Usuario: Muestra error
        else Contraseña correcta
            API-->>Frontend: 200 OK<br/>{ message, usuario }
            Frontend->>Frontend: Guardar en localStorage<br/>(correo, rol, nombre)
            Frontend->>Frontend: Actualizar estado UsuarioActual
            Frontend->>Frontend: Notificar cambio (OnCambio)
            Frontend-->>Usuario: Redirigir a "/" (Home)
        end
    end
```

## 3. Diagrama de Flujo - Registro de Usuario

```mermaid
sequenceDiagram
    actor Usuario
    participant Frontend as Frontend Blazor
    participant API as API Backend
    participant BD as Base de Datos
    participant BCrypt as BCrypt

    Usuario->>Frontend: Completa formulario<br/>registro
    Frontend->>Frontend: Validar campos<br/>(nombre, email, password)
    Frontend->>API: POST /api/auth/register<br/>{ nombre, correo, contrasena }
    API->>BD: SELECT COUNT(*) FROM usuarios<br/>WHERE correo = 'nuevo@correo.com'
    BD-->>API: Retornar count

    alt Correo ya existe
        API-->>Frontend: 400 Bad Request<br/>"El correo ya está registrado"
        Frontend-->>Usuario: Muestra error
    else Correo disponible
        API->>BCrypt: HashPassword(contrasena)
        BCrypt-->>API: Hash generado
        API->>API: Crear objeto Usuario<br/>Rol = "Cliente"
        API->>BD: INSERT INTO usuarios<br/>(nombre, correo, contrasena, rol, fecha_registro)
        BD-->>API: Usuario creado
        API-->>Frontend: 200 OK<br/>{ message, usuario }
        Frontend->>Frontend: Guardar en localStorage
        Frontend->>Frontend: Actualizar UsuarioActual
        Frontend-->>Usuario: Redirigir a "/" (Home)
    end
```

## 4. Diagrama de Arquitectura - Autenticación

```mermaid
graph TB
    subgraph "Frontend - Blazor WASM"
        A[Login.razor]
        B[AuthService]
        C[localStorage]
    end

    subgraph "Backend - ASP.NET Core API"
        D[AuthController]
        E[AdminController]
        F[RutaRDbContext]
    end

    subgraph "Base de Datos - PostgreSQL"
        G[(usuarios)]
    end

    subgraph "Seguridad"
        H[BCrypt.Net]
    end

    A -->|LoginAsync| B
    B -->|POST /api/auth/login| D
    D -->|Consultar| F
    F -->|Query| G
    G -->|Usuario| F
    F -->|Hash contrasena| H
    H -->|Verify| D
    D -->|Respuesta| B
    B -->|Guardar sesion| C

    D -->|POST /api/admin/create| E
    E -->|Crear admin| F
    F -->|INSERT| G

    style A fill:#e1f5ff
    style D fill:#ffe1e1
    style G fill:#e1ffe1
    style H fill:#fff4e1
```

## 5. Diagrama de Entidades - Sistema de Roles

```mermaid
graph LR
    A[Usuario] --> B{Rol}
    B -->|Cliente| C[Acceso Cliente]
    B -->|Administrador| D[Acceso Admin]

    C --> E[Ver Hoteles]
    C --> F[Ver Restaurantes]
    C --> G[Hacer Reservas]
    C --> H[Dejar Reseñas]

    D --> I[Gestión Usuarios]
    D --> J[Gestión Hoteles]
    D --> K[Gestión Restaurantes]
    D --> L[Ver Reportes]

    style A fill:#e1f5ff
    style D fill:#ffe1e1
    style C fill:#e1ffe1
```

---

## Leyendas

- **PK:** Primary Key (Clave Primaria)
- **FK:** Foreign Key (Clave Foránea)
- **UK:** Unique Key (Clave Única)
- **||--o{:** Uno a muchos
- **POST:** Método HTTP para crear recursos
- **GET:** Método HTTP para obtener recursos
