using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proeventos.api.Migrations
{
    public partial class migracaoadp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Categorias_CategoriaId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "Eventos_a");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_CategoriaId",
                table: "Eventos_a",
                newName: "IX_Eventos_a_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos_a",
                table: "Eventos_a",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_a_Categorias_CategoriaId",
                table: "Eventos_a",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_a_Categorias_CategoriaId",
                table: "Eventos_a");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos_a",
                table: "Eventos_a");

            migrationBuilder.RenameTable(
                name: "Eventos_a",
                newName: "Eventos");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_a_CategoriaId",
                table: "Eventos",
                newName: "IX_Eventos_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Categorias_CategoriaId",
                table: "Eventos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
