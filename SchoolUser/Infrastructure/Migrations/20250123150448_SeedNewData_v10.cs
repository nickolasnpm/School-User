using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v10 : Migration
    {
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

        private readonly Guid classCategoryId1 = new Guid("7a8f125a-1a3f-4cad-b36e-843f671a46b4");
        private readonly Guid classCategoryId2 = new Guid("68d628a4-2b3c-44ae-a436-477dcae41f8c");
        private readonly Guid classCategoryId3 = new Guid("b8a64967-ae58-48c6-b915-1f846c9b1308");
        private readonly Guid classCategoryId4 = new Guid("0c56ce68-abb0-433c-8477-362a0694d4d6");
        private readonly Guid classCategoryId5 = new Guid("144ea0ad-17e4-424c-b42d-8063d4fa7461");
        private readonly Guid classCategoryId6 = new Guid("96fd5d40-7d5f-4ef2-b0da-54a54174636c");
        private readonly Guid classCategoryId7 = new Guid("722ae07f-7c79-4d6e-86b9-883cfd51a465");
        private readonly Guid classCategoryId8 = new Guid("9a292af3-4060-4333-8bc7-f9e04bc427c1");
        private readonly Guid classCategoryId9 = new Guid("abcde7a4-f50d-49f7-96cc-6d21cde4aea1");
        private readonly Guid classCategoryId10 = new Guid("05e4fa77-c50b-460d-b56a-975ba5071b68");
        private readonly Guid classCategoryId11 = new Guid("78ba652f-c77c-4d21-8776-ee8fca7a71de");
        private readonly Guid classCategoryId12 = new Guid("85c038b2-50c9-4a24-8c66-ee7c2fe4babf");
        private readonly Guid classCategoryId13 = new Guid("7eba9143-c4ad-49f2-832e-73adf03f00ff");

        private readonly int AcademicYear = 2025;

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"UPDATE [User].[Batch] SET Code = 'OUT' WHERE Id =  '{batchId7}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassRank] SET Code = 'OUT' WHERE Id =  '{classRankId3}' ");

            migrationBuilder.DeleteData(
                schema: "User",
                table: "ClassStream",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    classStreamId1, classStreamId2, classStreamId3
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

            migrationBuilder.InsertData(
                schema: "User",
                table: "ClassCategory",
                columns: ["Id", "Code", "BatchId", "ClassStreamId", "AcademicYear", "ClassRankId"],
                values: new object[,]
                {
                    { classCategoryId1, "1-SNT-1", batchId1, classStreamId1, AcademicYear, classRankId1 },
                    { classCategoryId2, "1-ART-2", batchId1, classStreamId2, AcademicYear, classRankId2 },
                    { classCategoryId3, "2-SNT-1", batchId2, classStreamId1, AcademicYear, classRankId1 },
                    { classCategoryId4, "2-ART-2", batchId2, classStreamId2, AcademicYear, classRankId2 },
                    { classCategoryId5, "3-SNT-1", batchId3, classStreamId1, AcademicYear, classRankId1 },
                    { classCategoryId6, "3-ART-2", batchId3, classStreamId2, AcademicYear, classRankId2 },
                    { classCategoryId7, "4-SNT-1", batchId4, classStreamId1, AcademicYear, classRankId1 },
                    { classCategoryId8, "4-ART-2", batchId4, classStreamId2, AcademicYear, classRankId2 },
                    { classCategoryId9, "5-SNT-1", batchId5, classStreamId1, AcademicYear, classRankId1 },
                    { classCategoryId10, "5-ART-2", batchId5, classStreamId2, AcademicYear, classRankId2 },
                    { classCategoryId11, "6-SNT-1", batchId6, classStreamId1, AcademicYear, classRankId1 },
                    { classCategoryId12, "6-ART-2", batchId6, classStreamId2, AcademicYear, classRankId2 },
                    { classCategoryId13, "OUT-OUT-OUT", batchId7, classStreamId3, AcademicYear, classRankId3 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "User",
                table: "ClassCategory",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    classCategoryId1, classCategoryId2, classCategoryId3, classCategoryId4, classCategoryId5,
                    classCategoryId6, classCategoryId7, classCategoryId8, classCategoryId9, classCategoryId10,
                    classCategoryId11, classCategoryId12, classCategoryId13
                });
        }
    }
}
