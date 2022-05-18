using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekBoklusen.Server.Migrations
{
    public partial class movedPropToPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoaned",
                table: "Loans");

            migrationBuilder.AddColumn<bool>(
                name: "IsLoaned",
                table: "productCopies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoaned",
                table: "productCopies");

            migrationBuilder.AddColumn<bool>(
                name: "IsLoaned",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
