using Microsoft.EntityFrameworkCore.Migrations;

namespace OdataTest.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prod",
                table: "Prod");

            migrationBuilder.RenameTable(
                name: "Prod",
                newName: "Produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Prod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prod",
                table: "Prod",
                column: "ID");
        }
    }
}
