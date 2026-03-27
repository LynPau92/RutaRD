using Microsoft.EntityFrameworkCore;
using RutaRD.Core.Models;

namespace RutaRD.Api.Data
{
    public class RutaRDbContext : DbContext
    {
        public RutaRDbContext(DbContextOptions<RutaRDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<HotelServicio> HotelServicios { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<TurismoEcologico> TurismoEcologico { get; set; }
        public DbSet<TurismoCultural> TurismoCultural { get; set; }
        public DbSet<EventosActividades> EventosActividades { get; set; }
        public DbSet<Resena> Resenas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar nombres de tablas en minúsculas sin comillas
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Hotel>().ToTable("hoteles");
            modelBuilder.Entity<HotelServicio>().ToTable("hotel_servicios");
            modelBuilder.Entity<Restaurante>().ToTable("restaurantes");
            modelBuilder.Entity<TurismoEcologico>().ToTable("turismo_ecologico");
            modelBuilder.Entity<TurismoCultural>().ToTable("turismo_cultural");
            modelBuilder.Entity<EventosActividades>().ToTable("eventos_actividades");
            modelBuilder.Entity<Resena>().ToTable("resenas");
            modelBuilder.Entity<Reserva>().ToTable("reservas");

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Correo).IsUnique();
                entity.Property(e => e.Rol)
                    .HasDefaultValue("Cliente")
                    .IsRequired();
            });

            // Configuración de Hotel
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.PrecioNoche).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Estrellas).HasColumnType("decimal(2,1)");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("NOW()");
            });

            // Configuración de HotelServicio
            modelBuilder.Entity<HotelServicio>(entity =>
            {
                entity.HasOne(hs => hs.Hotel)
                    .WithMany(h => h.HotelServicios)
                    .HasForeignKey(hs => hs.HotelId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de Restaurante
            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.Property(e => e.Estrellas).HasColumnType("decimal(2,1)");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("NOW()");
            });

            // Configuración de TurismoEcologico
            modelBuilder.Entity<TurismoEcologico>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("NOW()");
            });

            // Configuración de TurismoCultural
            modelBuilder.Entity<TurismoCultural>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("NOW()");
            });

            // Configuración de EventosActividades
            modelBuilder.Entity<EventosActividades>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("NOW()");
            });

            // Configuración de Resena (polimórfica)
            modelBuilder.Entity<Resena>(entity =>
            {
                entity.Property(e => e.Calificacion).HasColumnType("decimal(2,1)");

                // Índice para búsquedas polimórficas
                entity.HasIndex(e => new { e.CategoriaId, e.CategoriaTipo });
            });

            // Configuración de Reserva
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.PrecioNoche).HasColumnType("decimal(10,2)");
                entity.Property(e => e.TotalEstimado).HasColumnType("decimal(10,2)");
                entity.Property(e => e.ITBIS).HasColumnType("decimal(10,2)");
                entity.Property(e => e.TotalConITBIS).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Estado)
                    .HasDefaultValue("Pendiente")
                    .IsRequired();

                entity.Property(e => e.FechaReserva).HasDefaultValueSql("NOW()");

                // Relaciones
                entity.HasOne(r => r.Usuario)
                    .WithMany(u => u.Reservas)
                    .HasForeignKey(r => r.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Hotel)
                    .WithMany(h => h.Reservas)
                    .HasForeignKey(r => r.HotelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
