using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S4.Migrations
{
    /// <inheritdoc />
    public partial class Change_Provinces_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "Provinces");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Cities",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                newName: "IX_Cities_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "Provinces",
                newName: "IX_Provinces_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "States");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "Cities",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                newName: "IX_Cities_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Provinces_CountryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
