using Microsoft.EntityFrameworkCore.Migrations;

namespace CMEG.Web.Migrations
{
    public partial class CreateIndexCentroAsistencial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CentrosAsistenciales_Nombre",
                table: "CentrosAsistenciales",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CentrosAsistenciales_Nombre",
                table: "CentrosAsistenciales");
        }
    }
}
