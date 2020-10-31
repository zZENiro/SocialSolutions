using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialSolutions.Migrations
{
    public partial class ImageAsURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Image");

            migrationBuilder.AddColumn<byte[]>(
                name: "Value",
                table: "Image",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
