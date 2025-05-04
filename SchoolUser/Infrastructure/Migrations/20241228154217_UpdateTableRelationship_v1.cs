using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableRelationship_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceStatus",
                schema: "User",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                schema: "User",
                table: "Teacher",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "User",
                table: "Teacher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibilityFocus",
                schema: "User",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponsibilityLevel",
                schema: "User",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibilityType",
                schema: "User",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                schema: "User",
                table: "Subject",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RealExitYear",
                schema: "User",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstimatedExitYear",
                schema: "User",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EntranceYear",
                schema: "User",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassCategoryId",
                schema: "User",
                table: "Student",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AcademicYear",
                schema: "User",
                table: "ClassSubject",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AcademicYear",
                schema: "User",
                table: "ClassCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ClassRankId",
                schema: "User",
                table: "ClassCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "User",
                table: "Batch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                schema: "User",
                table: "Batch",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccessModule",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassRank",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRank", x => x.Id);
                });

            Guid classRankId = Guid.NewGuid();

            migrationBuilder.InsertData(
                schema: "User",
                table: "ClassRank",
                columns: ["Id", "Name", "Code", "IsActive"],
                values: [classRankId, "A", "A001", true]);
                
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET ClassRankId = '{classRankId}' WHERE ClassRankId = '00000000-0000-0000-0000-000000000000'");

            migrationBuilder.CreateTable(
                name: "RoleAccessModule",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccessModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAccessModule_AccessModule_AccessModuleId",
                        column: x => x.AccessModuleId,
                        principalSchema: "User",
                        principalTable: "AccessModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAccessModule_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "User",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassCategory_ClassRankId",
                schema: "User",
                table: "ClassCategory",
                column: "ClassRankId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccessModule_AccessModuleId",
                schema: "User",
                table: "RoleAccessModule",
                column: "AccessModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccessModule_RoleId",
                schema: "User",
                table: "RoleAccessModule",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassCategory_ClassRank_ClassRankId",
                schema: "User",
                table: "ClassCategory",
                column: "ClassRankId",
                principalSchema: "User",
                principalTable: "ClassRank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassCategory_ClassRank_ClassRankId",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.DropTable(
                name: "ClassRank",
                schema: "User");

            migrationBuilder.DropTable(
                name: "RoleAccessModule",
                schema: "User");

            migrationBuilder.DropTable(
                name: "AccessModule",
                schema: "User");

            migrationBuilder.DropIndex(
                name: "IX_ClassCategory_ClassRankId",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ResponsibilityFocus",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ResponsibilityLevel",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ResponsibilityType",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "User",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "AcademicYear",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.DropColumn(
                name: "ClassRankId",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "User",
                table: "Batch");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "User",
                table: "Batch");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceStatus",
                schema: "User",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                schema: "User",
                table: "Teacher",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "RealExitYear",
                schema: "User",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstimatedExitYear",
                schema: "User",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntranceYear",
                schema: "User",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassCategoryId",
                schema: "User",
                table: "Student",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicYear",
                schema: "User",
                table: "ClassSubject",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "User",
                table: "ClassCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
