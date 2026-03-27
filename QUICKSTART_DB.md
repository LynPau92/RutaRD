# 🚀 Quick Start - Base de Datos RutaRD

## ⚡ Inicio Rápido (5 minutos)

### 1. Instalar PostgreSQL
```bash
sudo apt update && sudo apt install postgresql postgresql-contrib -y
sudo systemctl start postgresql
```

### 2. Crear Base de Datos
```bash
sudo -u postgres psql << EOF
CREATE DATABASE rutard OWNER rutard;
CREATE USER rutard WITH PASSWORD 'RutaRD2026!';
GRANT ALL PRIVILEGES ON DATABASE rutard TO rutard;
\q
EOF
```

### 3. Ejecutar API (con auto-creación de DB)
```bash
cd /home/Yasmany/RiderProjects/RutaRD/RutaRD.Api
dotnet run
```

¡Listo! La API estará en http://localhost:5193 con Swagger UI incluido.

---

## 📋 Verificación

```bash
# Probar API
curl http://localhost:5193/api/Hoteles | jq .

# Ver tablas creadas
psql -h localhost -U rutard -d rutard -c "\dt"

# Ver Swagger UI
firefox http://localhost:5193
```

---

## 🎯 Lo Que Se Creó

✅ **Backend API** con PostgreSQL
✅ **9 Modelos** de datos (Usuario, Hotel, Reserva, etc.)
✅ **3 Controllers** (Hoteles, Restaurantes, Reservas)
✅ **DbContext** con relaciones
✅ **Swagger UI** para testing
✅ **Documentación** completa

---

## 📖 Documentación Completa

- `DB_IMPLEMENTATION.md` - Guía detallada paso a paso
- `DB_IMPLEMENTATION_RESUMEN.md` - Resumen ejecutivo
- `MYSQL_ALTERNATIVE.md` - Si prefieres MySQL

---

## ⚙️ Cambiar Contraseña de DB

Editar `RutaRD.Api/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=rutard;Username=rutard;Password=TU_NUEVA_PASSWORD"
  }
}
```

---

## 🔄 Cambiar a MySQL

Ver `MYSQL_ALTERNATIVE.md` - Básicamente:
1. Cambiar paquete NuGet a `Pomelo.EntityFrameworkCore.MySql`
2. Cambiar `UseNpgsql` a `UseMySql`
3. Actualizar connection string

---

## 🐛 Problemas Comunes

**Error: "No se puede conectar a PostgreSQL"**
```bash
# Verificar que PostgreSQL está corriendo
sudo systemctl status postgresql

# Reiniciar si es necesario
sudo systemctl restart postgresql
```

**Error: "dotnet command not found"**
```bash
# Instalar .NET 10 SDK
# (Descargar desde https://dotnet.microsoft.com/download)
```

**Error: "Cannot find project"**
```bash
# Asegurarse de estar en el directorio correcto
cd /home/Yasmany/RiderProjects/RutaRD/RutaRD.Api
```

---

## 📞 Próximos Pasos

1. **Probar la API** con Swagger UI
2. **Migrar datos** existentes a la DB (Seed Data)
3. **Actualizar frontend** para usar HttpClient
4. **Implementar** autenticación JWT

---

**Estado:** ✅ Listo para usar
**Última actualización:** 2026-03-23
**Versión:** 1.0
