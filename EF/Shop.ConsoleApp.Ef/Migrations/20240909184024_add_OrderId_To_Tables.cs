using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.ConsoleApp.Ef.Migrations
{
    /// <inheritdoc />
    public partial class add_OrderId_To_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderItems");
        }
    }
}
