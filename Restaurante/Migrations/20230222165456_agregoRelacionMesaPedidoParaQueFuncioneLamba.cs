using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    /// <inheritdoc />
    public partial class agregoRelacionMesaPedidoParaQueFuncioneLamba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesaId",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedidos",
                column: "MesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_MesaId",
                table: "Pedidos",
                column: "MesaId",
                principalTable: "Mesas",
                principalColumn: "MesaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_MesaId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "MesaId",
                table: "Pedidos");
        }
    }
}
