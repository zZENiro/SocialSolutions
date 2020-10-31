using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialSolutions.Migrations
{
    public partial class upd_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccountId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
