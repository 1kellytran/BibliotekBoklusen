using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekBoklusen.Server.Migrations
{
    public partial class addedBoolLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isReturned",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isReturned",
                table: "Loans");
        }
    }
}
