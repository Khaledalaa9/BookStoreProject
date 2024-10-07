using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addBookid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPurchase");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BookId",
                table: "Purchases",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Books_BookId",
                table: "Purchases",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Books_BookId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_BookId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Purchases");

            migrationBuilder.CreateTable(
                name: "BookPurchase",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    PurchasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPurchase", x => new { x.BooksId, x.PurchasesId });
                    table.ForeignKey(
                        name: "FK_BookPurchase_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPurchase_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPurchase_PurchasesId",
                table: "BookPurchase",
                column: "PurchasesId");
        }
    }
}
