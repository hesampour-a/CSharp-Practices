using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class Add_Zooes_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZooId",
                table: "Partitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Zooes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zooes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partitions_ZooId",
                table: "Partitions",
                column: "ZooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partitions_Zooes_ZooId",
                table: "Partitions",
                column: "ZooId",
                principalTable: "Zooes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partitions_Zooes_ZooId",
                table: "Partitions");

            migrationBuilder.DropTable(
                name: "Zooes");

            migrationBuilder.DropIndex(
                name: "IX_Partitions_ZooId",
                table: "Partitions");

            migrationBuilder.DropColumn(
                name: "ZooId",
                table: "Partitions");
        }
    }
}
