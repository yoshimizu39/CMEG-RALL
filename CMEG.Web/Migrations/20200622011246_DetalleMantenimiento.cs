using Microsoft.EntityFrameworkCore.Migrations;

namespace CMEG.Web.Migrations
{
    public partial class DetalleMantenimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAtencion",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "IdEquipo",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "Persona",
                table: "Mantenimientos");

            migrationBuilder.AddColumn<string>(
                name: "NumeroMantenimiento",
                table: "Mantenimientos",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CentroAsistencialId",
                table: "Equipos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Equipos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Equipos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModeloId",
                table: "Equipos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetalleMantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEjecucion = table.Column<string>(nullable: true),
                    NumeroOTM = table.Column<string>(maxLength: 20, nullable: false),
                    Persona = table.Column<string>(maxLength: 60, nullable: false),
                    EquipoId = table.Column<int>(nullable: true),
                    MantenimientoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleMantenimiento_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleMantenimiento_Mantenimientos_MantenimientoId",
                        column: x => x.MantenimientoId,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CentroAsistencialId",
                table: "Equipos",
                column: "CentroAsistencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_EmpresaId",
                table: "Equipos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_MarcaId",
                table: "Equipos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_ModeloId",
                table: "Equipos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMantenimiento_EquipoId",
                table: "DetalleMantenimiento",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMantenimiento_MantenimientoId",
                table: "DetalleMantenimiento",
                column: "MantenimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_CentrosAsistenciales_CentroAsistencialId",
                table: "Equipos",
                column: "CentroAsistencialId",
                principalTable: "CentrosAsistenciales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Empresas_EmpresaId",
                table: "Equipos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Marcas_MarcaId",
                table: "Equipos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Modelos_ModeloId",
                table: "Equipos",
                column: "ModeloId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_CentrosAsistenciales_CentroAsistencialId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Empresas_EmpresaId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Marcas_MarcaId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Modelos_ModeloId",
                table: "Equipos");

            migrationBuilder.DropTable(
                name: "DetalleMantenimiento");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_CentroAsistencialId",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_EmpresaId",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_MarcaId",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_ModeloId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "NumeroMantenimiento",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "CentroAsistencialId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "ModeloId",
                table: "Equipos");

            migrationBuilder.AddColumn<string>(
                name: "FechaAtencion",
                table: "Mantenimientos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipo",
                table: "Mantenimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Persona",
                table: "Mantenimientos",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}
