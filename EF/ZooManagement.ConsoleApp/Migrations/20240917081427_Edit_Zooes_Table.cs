using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Zooes_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Zooes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Zooes");
        }
    }
}
