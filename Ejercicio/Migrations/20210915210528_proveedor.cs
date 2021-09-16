using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejercicio.Migrations
{
    public partial class proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proovedores_ProovedorId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proovedores",
                table: "Proovedores");

            migrationBuilder.RenameTable(
                name: "Proovedores",
                newName: "Proveedores");

            migrationBuilder.RenameIndex(
                name: "IX_Proovedores_Descripcion",
                table: "Proveedores",
                newName: "IX_Proveedores_Descripcion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProovedorId",
                table: "Productos",
                column: "ProovedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProovedorId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proovedores");

            migrationBuilder.RenameIndex(
                name: "IX_Proveedores_Descripcion",
                table: "Proovedores",
                newName: "IX_Proovedores_Descripcion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proovedores",
                table: "Proovedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proovedores_ProovedorId",
                table: "Productos",
                column: "ProovedorId",
                principalTable: "Proovedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
