using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFCore.Migrations
{
    public partial class AlterTablePedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Pedidos",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pedidos",
                newName: "status");
        }
    }
}
