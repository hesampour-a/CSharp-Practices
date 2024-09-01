using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S2.Migrations
{
    /// <inheritdoc />
    public partial class AddFollowerIntrestedHashtagsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FollowerIntrestedHashtags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HashtagId = table.Column<int>(type: "int", nullable: false),
                    FollowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowerIntrestedHashtags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowerIntrestedHashtags_Followers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Followers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowerIntrestedHashtags_Hashtags_HashtagId",
                        column: x => x.HashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowerIntrestedHashtags_FollowerId",
                table: "FollowerIntrestedHashtags",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowerIntrestedHashtags_HashtagId",
                table: "FollowerIntrestedHashtags",
                column: "HashtagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowerIntrestedHashtags");
        }
    }
}
