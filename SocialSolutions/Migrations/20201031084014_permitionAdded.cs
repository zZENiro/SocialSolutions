using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialSolutions.Migrations
{
    public partial class permitionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Permit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersPermits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    PermitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPermits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPermits_Permit_PermitId",
                        column: x => x.PermitId,
                        principalTable: "Permit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersPermits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPermits_PermitId",
                table: "UsersPermits",
                column: "PermitId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPermits_UserId",
                table: "UsersPermits",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPermits");

            migrationBuilder.DropTable(
                name: "Permit");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Users");
        }
    }
}
