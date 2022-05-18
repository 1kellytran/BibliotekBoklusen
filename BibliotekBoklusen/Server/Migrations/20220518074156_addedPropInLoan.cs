﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekBoklusen.Server.Migrations
{
    public partial class addedPropInLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoaned",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoaned",
                table: "Loans");
        }
    }
}
