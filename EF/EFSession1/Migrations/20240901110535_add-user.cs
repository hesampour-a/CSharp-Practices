using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSession1.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UniversityTeachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UniversityTeachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UniversityTeachers");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "UniversityTeachers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UniversityTeachers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UniversityStudents");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UniversityStudents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UniversityStudents");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "UniversityStudents");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UniversityStudents");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UniversityTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UniversityStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeachers_UserId",
                table: "UniversityTeachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniversityStudents_UserId",
                table: "UniversityStudents",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityStudents_User_UserId",
                table: "UniversityStudents",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityTeachers_User_UserId",
                table: "UniversityTeachers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniversityStudents_User_UserId",
                table: "UniversityStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityTeachers_User_UserId",
                table: "UniversityTeachers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_UniversityTeachers_UserId",
                table: "UniversityTeachers");

            migrationBuilder.DropIndex(
                name: "IX_UniversityStudents_UserId",
                table: "UniversityStudents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UniversityTeachers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UniversityStudents");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UniversityTeachers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UniversityTeachers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UniversityTeachers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "UniversityTeachers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UniversityTeachers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UniversityStudents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UniversityStudents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UniversityStudents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "UniversityStudents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UniversityStudents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
