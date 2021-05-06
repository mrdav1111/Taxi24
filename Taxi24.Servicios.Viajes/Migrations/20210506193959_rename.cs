using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi24.Servicios.Viajes.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Viaje",
                table: "Viaje");

            migrationBuilder.RenameTable(
                name: "Viaje",
                newName: "Viajes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viajes",
                table: "Viajes",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Viajes",
                table: "Viajes");

            migrationBuilder.RenameTable(
                name: "Viajes",
                newName: "Viaje");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viaje",
                table: "Viaje",
                column: "ID");
        }
    }
}
