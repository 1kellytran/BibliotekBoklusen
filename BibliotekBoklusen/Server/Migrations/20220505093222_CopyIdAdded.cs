using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekBoklusen.Server.Migrations
{
    public partial class CopyIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiesOwned",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Loans",
                newName: "CopyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CopyId",
                table: "Loans",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CopiesOwned",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
