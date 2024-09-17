using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Tickets_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Partitions_PartitionId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PartitionId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "PartitionId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PartitionId",
                table: "Tickets",
                column: "PartitionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Partitions_PartitionId",
                table: "Tickets",
                column: "PartitionId",
                principalTable: "Partitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Partitions_PartitionId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PartitionId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "PartitionId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PartitionId",
                table: "Tickets",
                column: "PartitionId",
                unique: true,
                filter: "[PartitionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Partitions_PartitionId",
                table: "Tickets",
                column: "PartitionId",
                principalTable: "Partitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
