using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingManagement.ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class Add_MaxUnit_And_MaxFloor_Number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxUnitNumber",
                table: "Floors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxFloorNumber",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxUnitNumber",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "MaxFloorNumber",
                table: "Blocks");
        }
    }
}
