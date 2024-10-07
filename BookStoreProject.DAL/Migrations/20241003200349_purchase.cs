using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class purchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPurchase_Books_BooksId",
                table: "BookPurchase");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "BookPurchase",
                newName: "BookId");

            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BookPurchase_Books_BookId",
                table: "BookPurchase",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPurchase_Books_BookId",
                table: "BookPurchase");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Purchases");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookPurchase",
                newName: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPurchase_Books_BooksId",
                table: "BookPurchase",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
