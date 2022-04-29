using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekBoklusen.Server.Migrations
{
    public partial class configuredRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Products_Product_Id",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_User_Id",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_Product_Id",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_User_Id",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Loans");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ProductId",
                table: "Loans",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Products_ProductId",
                table: "Loans",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Products_ProductId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_ProductId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                table: "Loans");

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_Product_Id",
                table: "Loans",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_User_Id",
                table: "Loans",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Products_Product_Id",
                table: "Loans",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_User_Id",
                table: "Loans",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
