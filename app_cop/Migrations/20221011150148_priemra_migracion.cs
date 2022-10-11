using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace app_cop.Migrations
{
    public partial class priemra_migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "text", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tipoMovimiento",
                columns: table => new
                {
                    IdTipoMovimiento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Costo = table.Column<decimal>(type: "numeric(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tipoMovimiento", x => x.IdTipoMovimiento);
                });

            migrationBuilder.CreateTable(
                name: "tbl_empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_tbl_empleados_tbl_roles_RolId",
                        column: x => x.RolId,
                        principalTable: "tbl_roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_movimientos",
                columns: table => new
                {
                    IdMovimiento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaMov = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TipoMovimientoId = table.Column<int>(type: "integer", nullable: false),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric(6,2)", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_movimientos", x => x.IdMovimiento);
                    table.ForeignKey(
                        name: "FK_tbl_movimientos_tbl_empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "tbl_empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_movimientos_tbl_tipoMovimiento_TipoMovimientoId",
                        column: x => x.TipoMovimientoId,
                        principalTable: "tbl_tipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_empleados_RolId",
                table: "tbl_empleados",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_movimientos_EmpleadoId",
                table: "tbl_movimientos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_movimientos_TipoMovimientoId",
                table: "tbl_movimientos",
                column: "TipoMovimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_movimientos");

            migrationBuilder.DropTable(
                name: "tbl_empleados");

            migrationBuilder.DropTable(
                name: "tbl_tipoMovimiento");

            migrationBuilder.DropTable(
                name: "tbl_roles");
        }
    }
}
