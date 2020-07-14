using Microsoft.EntityFrameworkCore.Migrations;

namespace CMEG.Web.Migrations
{
    public partial class EquipoMantenimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Mantenimientos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_EquipoId",
                table: "Mantenimientos",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Equipos_EquipoId",
                table: "Mantenimientos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Equipos_EquipoId",
                table: "Mantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_Mantenimientos_EquipoId",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Mantenimientos");
        }
    }
}
