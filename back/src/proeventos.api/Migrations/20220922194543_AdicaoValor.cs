using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proeventos.api.Migrations
{
    public partial class AdicaoValor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Eventos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Eventos");
        }
    }
}
