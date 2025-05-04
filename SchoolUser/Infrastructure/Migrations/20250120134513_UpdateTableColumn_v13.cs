using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableColumn_v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponsibilityLevel",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "SerialTag",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "SerialTag",
                schema: "User",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "SerialTag",
                schema: "User",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialTag",
                schema: "User",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibilityLevel",
                schema: "User",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialTag",
                schema: "User",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerialTag",
                schema: "User",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
