using Microsoft.EntityFrameworkCore.Migrations;

namespace CMEG.Web.Migrations
{
    public partial class addlogoempresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Empresas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Empresas");
        }
    }
}
