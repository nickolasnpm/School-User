using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateTableColumn_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                schema: "User",
                table: "ClassCategory",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "User",
                table: "ClassStream",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "User",
                table: "Batch",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "User",
                table: "ClassStream");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "User",
                table: "Batch");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "User",
                table: "ClassCategory",
                newName: "isActive");
        }
    }
}
