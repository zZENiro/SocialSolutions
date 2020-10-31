using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialSolutions.Migrations
{
    public partial class modelCahnged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Location",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Describtion = table.Column<string>(nullable: true),
                    PhotoId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Community_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Community_Image_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunitiesHobbies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityId = table.Column<int>(nullable: true),
                    HobbyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitiesHobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunitiesHobbies_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommunitiesHobbies_Hobby_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersCommunities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    CommunityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCommunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCommunities_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationId",
                table: "Users",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesHobbies_CommunityId",
                table: "CommunitiesHobbies",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesHobbies_HobbyId",
                table: "CommunitiesHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Community_OwnerId",
                table: "Community",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Community_PhotoId",
                table: "Community",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunities_CommunityId",
                table: "UsersCommunities",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunities_UserId",
                table: "UsersCommunities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Location_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Location_LocationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CommunitiesHobbies");

            migrationBuilder.DropTable(
                name: "UsersCommunities");

            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropIndex(
                name: "IX_Users_LocationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Location");
        }
    }
}
