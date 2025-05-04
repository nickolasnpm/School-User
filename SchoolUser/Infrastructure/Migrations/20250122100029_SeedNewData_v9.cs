using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v9 : Migration
    {

        private readonly Guid accessModuleId1 = new Guid("60efe4fc-6624-4bf6-ae20-20d5f8866774");
        private readonly Guid accessModuleId2 = new Guid("874b07ce-c4e7-4a2b-a549-d2a050b1805b");
        private readonly Guid accessModuleId3 = new Guid("31c665e1-020d-4e17-92cc-fac24464a794");
        private readonly Guid accessModuleId4 = new Guid("ec054965-c5ad-4d0e-9c31-42d283acc94b");
        private readonly Guid accessModuleId5 = new Guid("33d7a4b3-1bc2-4c3a-a88c-8e7b8e9934d8");
        private readonly Guid accessModuleId6 = new Guid("6a053b51-9653-46a5-a091-67295247ea28");

        private readonly Guid studentId = new Guid("F704B160-7A18-4B85-A393-7728F72261F5");
        private readonly Guid teacherId = new Guid("30909974-D5C8-4F98-B12C-2F5D56C84257");
        private readonly Guid adminId = new Guid("4A23CDCC-C914-485E-9168-44AD84624EC9");

        private readonly Guid roleAccessModuleId1 = new Guid("c7b0d9dc-6d4c-4e16-b2ae-3ee75446e6f0");
        private readonly Guid roleAccessModuleId2 = new Guid("49f8ad9c-e39b-42e8-bca2-c11e6791815b");
        private readonly Guid roleAccessModuleId3 = new Guid("6e74b43e-8ba5-4787-bd5a-0212169e504e");
        private readonly Guid roleAccessModuleId4 = new Guid("82abbf4e-6b6d-428c-a10d-3b6de6ab3a5d");
        private readonly Guid roleAccessModuleId5 = new Guid("215e753b-8694-4604-98f0-dc7664f8d9ac");
        private readonly Guid roleAccessModuleId6 = new Guid("0de3e6a0-80b4-4db8-8ba5-59ef47243db7");
        private readonly Guid roleAccessModuleId7 = new Guid("d2598e93-ca8a-4ec8-88d9-95d904bbfa5f");
        private readonly Guid roleAccessModuleId8 = new Guid("118d0d15-e6ae-400f-90b7-137ab9f2758f");
        private readonly Guid roleAccessModuleId9 = new Guid("29684838-7b24-4785-b249-28575747b7f9");
        private readonly Guid roleAccessModuleId10 = new Guid("6f37ad3e-551b-4a3c-9173-676ccb375e26");
        private readonly Guid roleAccessModuleId11 = new Guid("e5fb568a-f055-4658-a6bd-5a22e3da7adc");
        private readonly Guid roleAccessModuleId12 = new Guid("7db1e776-37a7-4052-b433-8c9c7fb78914");
        private readonly Guid roleAccessModuleId13 = new Guid("ded92941-103e-4087-bc9b-26ba0422ce81");
        private readonly Guid roleAccessModuleId14 = new Guid("28196a28-a14b-44df-abed-fa8c8aeede18");
        private readonly Guid roleAccessModuleId15 = new Guid("9dbc5196-5ca3-4f6c-9c70-712f5e43b464");
        private readonly Guid roleAccessModuleId16 = new Guid("3110cb86-e212-4d53-8752-67ed34904c6e");
        private readonly Guid roleAccessModuleId17 = new Guid("20d5cc53-1c3f-4f31-9ef8-3f5a6a915a2b");
        private readonly Guid roleAccessModuleId18 = new Guid("c033717c-f28e-4cc0-9aa7-c91775eb3043");

        private readonly Guid batchId1 = new Guid("1485a6c3-7e53-4b37-a087-bbe2f826e209");
        private readonly Guid batchId2 = new Guid("a39caa58-ffca-4fe1-a6ae-f2a99d52462e");
        private readonly Guid batchId3 = new Guid("5408f979-1dbd-4099-ab22-99bb2a130f64");
        private readonly Guid batchId4 = new Guid("dd090135-02af-4494-9ea3-82d2e16c7e0b");
        private readonly Guid batchId5 = new Guid("b6cf2708-5742-4fa2-ac79-0ac3d808e862");
        private readonly Guid batchId6 = new Guid("2268cb21-ddb7-41f8-baf2-fff6d078121c");
        private readonly Guid batchId7 = new Guid("a3c07e49-544c-41f4-9053-626969327457");

        private readonly Guid classRankId1 = new Guid("4feaafb2-a22e-49e0-886b-18465c20e3a6");
        private readonly Guid classRankId2 = new Guid("50912890-6ce4-48b7-9bbe-01d377d72b6b");
        private readonly Guid classRankId3 = new Guid("635ee98a-2cb4-45d9-956b-6900f6cc81b4");


        private readonly Guid classStreamId1 = new Guid("95ea2b5d-39ca-44ca-ab33-9714298fdf87");
        private readonly Guid classStreamId2 = new Guid("e54c04de-2156-4b88-8360-69ff4c2cae71");
        private readonly Guid classStreamId3 = new Guid("be9cddc5-c64c-4711-80eb-37bb8f867cec");


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
                    { accessModuleId4, "School Updates"},
                    { accessModuleId5, "School Library"},
                    { accessModuleId6, "School Market"}
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
                    { roleAccessModuleId5, teacherId, accessModuleId5 },
                    { roleAccessModuleId6, teacherId, accessModuleId6 },
                    { roleAccessModuleId7, studentId, accessModuleId1 },
                    { roleAccessModuleId8, studentId, accessModuleId2 },
                    { roleAccessModuleId9, studentId, accessModuleId3 },
                    { roleAccessModuleId10, studentId, accessModuleId4 },
                    { roleAccessModuleId11, studentId, accessModuleId5 },
                    { roleAccessModuleId12, studentId, accessModuleId6 },
                    { roleAccessModuleId13, adminId, accessModuleId1 },
                    { roleAccessModuleId14, adminId, accessModuleId2 },
                    { roleAccessModuleId15, adminId, accessModuleId3 },
                    { roleAccessModuleId16, adminId, accessModuleId4 },
                    { roleAccessModuleId17, adminId, accessModuleId5 },
                    { roleAccessModuleId18, adminId, accessModuleId6 },
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Batch",
                columns: ["Id", "Name", "IsActive", "Code", "TeacherId"],
                values: new object[,]
                {
                    { batchId1, "First", true, "1", null },
                    { batchId2, "Second", true, "2", null },
                    { batchId3, "Third", true, "3", null },
                    { batchId4, "Fourth", true, "4", null },
                    { batchId5, "Fifth", true, "5", null },
                    { batchId6, "Sixth", true, "6", null },
                    { batchId7, "Out Of School", true, "OSS", null }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "ClassRank",
                columns: ["Id", "Name", "IsActive", "Code"],
                values: new object[,]
                {
                    { classRankId1, "First", true, "A" },
                    { classRankId2, "Second", true, "B" },
                    { classRankId3, "Out Of School", true, "OSS" }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "ClassStream",
                columns: ["Id", "Name", "IsActive", "Code"],
                values: new object[,]
                {
                    { classStreamId1, "Science", true, "SNT" },
                    { classStreamId2, "Art", true, "ART" },
                    { classStreamId3, "Out Of School", true, "OUT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "User",
                table: "ClassStream",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    classStreamId1, classStreamId2, classStreamId3
                });

            migrationBuilder.DeleteData(
                schema: "User",
                table: "ClassRank",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    classRankId1, classRankId2, classRankId3
                });

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Batch",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    batchId1, batchId2, batchId3, batchId4, batchId5, batchId6, batchId7
                });

            migrationBuilder.DeleteData(
                schema: "User",
                table: "AccessModule",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    roleAccessModuleId1, roleAccessModuleId2, roleAccessModuleId3,
                    roleAccessModuleId4, roleAccessModuleId5, roleAccessModuleId6,
                    roleAccessModuleId7, roleAccessModuleId8, roleAccessModuleId9,
                    roleAccessModuleId10, roleAccessModuleId11, roleAccessModuleId12,
                    roleAccessModuleId13, roleAccessModuleId14, roleAccessModuleId15,
                    roleAccessModuleId16, roleAccessModuleId17, roleAccessModuleId18
                });

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleAccessModule",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    accessModuleId1, accessModuleId2, accessModuleId3,
                    accessModuleId4, accessModuleId5, accessModuleId6
                });
        }

    }
}
