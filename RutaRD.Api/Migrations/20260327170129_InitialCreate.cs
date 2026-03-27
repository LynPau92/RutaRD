using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RutaRD.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventos_actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SitioWeb = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Fecha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Horario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PrecioEntrada = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos_actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hoteles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Estrellas = table.Column<double>(type: "numeric(2,1)", nullable: false),
                    PrecioNoche = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SitioWeb = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoteles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "restaurantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Estrellas = table.Column<double>(type: "numeric(2,1)", nullable: false),
                    Telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SitioWeb = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    RangoPrecios = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    OpcionVegetariana = table.Column<bool>(type: "boolean", nullable: false),
                    OpcionVegana = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "turismo_cultural",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SitioWeb = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    TipoLugar = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Horario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PrecioEntrada = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turismo_cultural", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "turismo_ecologico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SitioWeb = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    TipoLugar = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TipoActividad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NivelDificultad = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PrecioEntrada = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Horario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turismo_ecologico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Contrasena = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Rol = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Cliente"),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hotel_servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    Servicio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotel_servicios_hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resenas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreVisitante = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Comentario = table.Column<string>(type: "text", nullable: true),
                    Calificacion = table.Column<double>(type: "numeric(2,1)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false),
                    CategoriaTipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EventosActividadesId = table.Column<int>(type: "integer", nullable: true),
                    HotelId = table.Column<int>(type: "integer", nullable: true),
                    RestauranteId = table.Column<int>(type: "integer", nullable: true),
                    TurismoCulturalId = table.Column<int>(type: "integer", nullable: true),
                    TurismoEcologicoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resenas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resenas_eventos_actividades_EventosActividadesId",
                        column: x => x.EventosActividadesId,
                        principalTable: "eventos_actividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_resenas_hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hoteles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_resenas_restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "restaurantes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_resenas_turismo_cultural_TurismoCulturalId",
                        column: x => x.TurismoCulturalId,
                        principalTable: "turismo_cultural",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_resenas_turismo_ecologico_TurismoEcologicoId",
                        column: x => x.TurismoEcologicoId,
                        principalTable: "turismo_ecologico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    NombreCliente = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Noches = table.Column<int>(type: "integer", nullable: false),
                    Adultos = table.Column<int>(type: "integer", nullable: false),
                    Ninos = table.Column<int>(type: "integer", nullable: false),
                    Habitaciones = table.Column<int>(type: "integer", nullable: false),
                    PrecioNoche = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TotalEstimado = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ITBIS = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TotalConITBIS = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    SolicitudesEspeciales = table.Column<string>(type: "text", nullable: true),
                    NumeroFactura = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservas_hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hotel_servicios_HotelId",
                table: "hotel_servicios",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_resenas_CategoriaId_CategoriaTipo",
                table: "resenas",
                columns: new[] { "CategoriaId", "CategoriaTipo" });

            migrationBuilder.CreateIndex(
                name: "IX_resenas_EventosActividadesId",
                table: "resenas",
                column: "EventosActividadesId");

            migrationBuilder.CreateIndex(
                name: "IX_resenas_HotelId",
                table: "resenas",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_resenas_RestauranteId",
                table: "resenas",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_resenas_TurismoCulturalId",
                table: "resenas",
                column: "TurismoCulturalId");

            migrationBuilder.CreateIndex(
                name: "IX_resenas_TurismoEcologicoId",
                table: "resenas",
                column: "TurismoEcologicoId");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_HotelId",
                table: "reservas",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_UsuarioId",
                table: "reservas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Correo",
                table: "usuarios",
                column: "Correo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hotel_servicios");

            migrationBuilder.DropTable(
                name: "resenas");

            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "eventos_actividades");

            migrationBuilder.DropTable(
                name: "restaurantes");

            migrationBuilder.DropTable(
                name: "turismo_cultural");

            migrationBuilder.DropTable(
                name: "turismo_ecologico");

            migrationBuilder.DropTable(
                name: "hoteles");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
