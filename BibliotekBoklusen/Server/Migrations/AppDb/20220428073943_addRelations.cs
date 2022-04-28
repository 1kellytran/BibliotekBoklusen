using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekBoklusen.Server.Migrations.AppDb
{
    public partial class addRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Creators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductCreatorModel",
                columns: table => new
                {
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCreatorModel", x => new { x.CreatorId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCreatorModel_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCreatorModel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creators_ProductId",
                table: "Creators",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCreatorModel_ProductId",
                table: "ProductCreatorModel",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Creators_Products_ProductId",
                table: "Creators",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creators_Products_ProductId",
                table: "Creators");

            migrationBuilder.DropTable(
                name: "ProductCreatorModel");

            migrationBuilder.DropIndex(
                name: "IX_Creators_ProductId",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Creators");
        }
    }
}
