using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialSolutions.Migrations
{
    public partial class addedGroupsAndDocs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserImage");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "EventImage");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "UserImage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "EventImage",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersGroups_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserImage_ImageId",
                table: "UserImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventImage_ImageId",
                table: "EventImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                table: "Document",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ImageId",
                table: "Group",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_GroupId",
                table: "UsersGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_UserId",
                table: "UsersGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventImage_Image_ImageId",
                table: "EventImage",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImage_Image_ImageId",
                table: "UserImage",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventImage_Image_ImageId",
                table: "EventImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImage_Image_ImageId",
                table: "UserImage");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "UsersGroups");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_UserImage_ImageId",
                table: "UserImage");

            migrationBuilder.DropIndex(
                name: "IX_EventImage_ImageId",
                table: "EventImage");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "UserImage");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "EventImage");

            migrationBuilder.AddColumn<byte[]>(
                name: "Value",
                table: "UserImage",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Value",
                table: "EventImage",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
