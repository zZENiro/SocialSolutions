using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialSolutions.Migrations
{
    public partial class setDocUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Document");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Document",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Document");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Document",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
