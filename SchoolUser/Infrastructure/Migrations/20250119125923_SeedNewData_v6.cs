using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolUser.Domain.Models;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v6 : Migration
    {
        static Guid accessModuleId1 = Guid.NewGuid();
        static Guid accessModuleId2 = Guid.NewGuid();
        static Guid accessModuleId3 = Guid.NewGuid();
        static Guid accessModuleId4 = Guid.NewGuid();

        static Guid teacherId = new Guid("30909974-D5C8-4F98-B12C-2F5D56C84257");
        static Guid studentId = new Guid("F704B160-7A18-4B85-A393-7728F72261F5");
        static Guid admindId = new Guid("4A23CDCC-C914-485E-9168-44AD84624EC9");

        static Guid roleAccessModuleId1 = Guid.NewGuid();
        static Guid roleAccessModuleId2 = Guid.NewGuid();
        static Guid roleAccessModuleId3 = Guid.NewGuid();
        static Guid roleAccessModuleId4 = Guid.NewGuid();
        static Guid roleAccessModuleId5 = Guid.NewGuid();
        static Guid roleAccessModuleId6 = Guid.NewGuid();
        static Guid roleAccessModuleId7 = Guid.NewGuid();
        static Guid roleAccessModuleId8 = Guid.NewGuid();
        static Guid roleAccessModuleId9 = Guid.NewGuid();
        static Guid roleAccessModuleId10 = Guid.NewGuid();
        static Guid roleAccessModuleId11 = Guid.NewGuid();
        static Guid roleAccessModuleId12 = Guid.NewGuid();


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            schema: "User",
                            table: "AccessModule",
                            columns: ["Id", "Name"],
                            values: new object[,]
                            {
                                { accessModuleId1, "Class Attendance" },
                                { accessModuleId2, "Examination Result" },
                                { accessModuleId3, "Learning Center"},
                                { accessModuleId4, "Teacher Assessment"}
                            });

            migrationBuilder.InsertData(
                            schema: "User",
                            table: "RoleAccessModule",
                            columns: ["Id", "RoleId", "AccessModuleId"],
                            values: new object[,]
                            {
                                { roleAccessModuleId1, teacherId, accessModuleId1 },
                                { roleAccessModuleId2, teacherId, accessModuleId2 },
                                { roleAccessModuleId3, teacherId, accessModuleId3 },
                                { roleAccessModuleId4, teacherId, accessModuleId4 },
                                { roleAccessModuleId5, studentId, accessModuleId1 },
                                { roleAccessModuleId6, studentId, accessModuleId2 },
                                { roleAccessModuleId7, studentId, accessModuleId3 },
                                { roleAccessModuleId8, studentId, accessModuleId4 },
                                { roleAccessModuleId9, admindId, accessModuleId1 },
                                { roleAccessModuleId10, admindId, accessModuleId2 },
                                { roleAccessModuleId11, admindId, accessModuleId3 },
                                { roleAccessModuleId12, admindId, accessModuleId4 },
                            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Delete data from RoleAccessModule table
            migrationBuilder.DeleteData(
                schema: "SchoolUser",
                table: "RoleAccessModule",
                keyColumn: "Id",
                keyValues:
                [
                    roleAccessModuleId1, roleAccessModuleId2, roleAccessModuleId3, roleAccessModuleId4,
                    roleAccessModuleId5, roleAccessModuleId6, roleAccessModuleId7, roleAccessModuleId8,
                    roleAccessModuleId9, roleAccessModuleId10, roleAccessModuleId11, roleAccessModuleId12
                ]);

            // Delete data from AccessModule table
            migrationBuilder.DeleteData(
                schema: "SchoolUser",
                table: "AccessModule",
                keyColumn: "Id",
                keyValues:
                [
                    accessModuleId1, accessModuleId2, accessModuleId3, accessModuleId4
                ]);
        }

    }
}
