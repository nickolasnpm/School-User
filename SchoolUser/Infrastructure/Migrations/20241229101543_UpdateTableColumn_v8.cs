using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableColumn_v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialTag",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "SerialTag",
                schema: "User",
                table: "Student");
        }
    }
}
