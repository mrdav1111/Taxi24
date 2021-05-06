using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi24.Servicios.Facturas.Migrations
{
    public partial class addfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmpresaID",
                table: "Facturas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "Facturas");
        }
    }
}
