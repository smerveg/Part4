using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreWebAPI.Persistence.Migrations
{
    public partial class pk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseBook",
                table: "PurchaseBook");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseBookID",
                table: "PurchaseBook",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseBook",
                table: "PurchaseBook",
                column: "PurchaseBookID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBook_BookID",
                table: "PurchaseBook",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseBook",
                table: "PurchaseBook");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBook_BookID",
                table: "PurchaseBook");

            migrationBuilder.DropColumn(
                name: "PurchaseBookID",
                table: "PurchaseBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseBook",
                table: "PurchaseBook",
                columns: new[] { "BookID", "PurchaseID" });
        }
    }
}
