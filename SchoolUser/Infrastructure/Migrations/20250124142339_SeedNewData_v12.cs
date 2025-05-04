using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v12 : Migration
    {
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

        private readonly string classCategoryCode1 = "1-SNT-A";
        private readonly string classCategoryCode2 = "1-ART-B";
        private readonly string classCategoryCode3 = "2-SNT-A";
        private readonly string classCategoryCode4 = "2-ART-B";
        private readonly string classCategoryCode5 = "3-SNT-A";
        private readonly string classCategoryCode6 = "3-ART-B";
        private readonly string classCategoryCode7 = "4-SNT-A";
        private readonly string classCategoryCode8 = "4-ART-B";
        private readonly string classCategoryCode9 = "5-SNT-A";
        private readonly string classCategoryCode10 = "5-ART-B";
        private readonly string classCategoryCode11 = "6-SNT-A";
        private readonly string classCategoryCode12 = "6-ART-B";


        private readonly Guid subjectId1 = new Guid("5ee55784-143c-41c7-9888-644a2c90979c");
        private readonly Guid subjectId2 = new Guid("9fa34eb8-bc77-4b89-8abc-482f881683f0");
        private readonly Guid subjectId3 = new Guid("03102356-c6e9-4259-9969-bd8b4835b28b");
        private readonly Guid subjectId4 = new Guid("2cf81e7b-c1ea-43b0-b9af-149f628a7003");
        private readonly Guid subjectId5 = new Guid("f9830b30-c761-4c42-825c-74fdd3df65ab");
        private readonly Guid subjectId6 = new Guid("6c6d6faf-ca7c-47bb-8116-df67a78b9a1a");
        private readonly Guid subjectId7 = new Guid("f7286e2b-d1e0-4a86-ad6b-62c2fdd53c18");
        private readonly Guid subjectId8 = new Guid("dc3916d8-de66-4980-add7-bd17c3515c44");

        private readonly string subjectCode1 = "CHE";
        private readonly string subjectCode2 = "BIO";
        private readonly string subjectCode3 = "PHY";
        private readonly string subjectCode4 = "MATH";
        private readonly string subjectCode5 = "BM";
        private readonly string subjectCode6 = "BI";
        private readonly string subjectCode7 = "ME";
        private readonly string subjectCode8 = "TE";

        private readonly Guid classSubjectId1 = new Guid("4c6fe73b-8e2e-4a4e-8645-25a7fc85db63");
        private readonly Guid classSubjectId2 = new Guid("b08901ad-51d8-48ae-b2d5-e65c7eece0ae");
        private readonly Guid classSubjectId3 = new Guid("f20e400f-e05a-418f-b08d-4663b2ba0e22");
        private readonly Guid classSubjectId4 = new Guid("3d55eb70-aeec-4aae-9aaa-3c4d568a6d30");
        private readonly Guid classSubjectId5 = new Guid("a0c43464-473e-4db7-a61b-a8aaf036aafe");
        private readonly Guid classSubjectId6 = new Guid("c0d25057-649e-41ec-bb70-b57da2cfab2b");
        private readonly Guid classSubjectId7 = new Guid("daa9a15a-f07f-4df2-9151-4a4de7110cb3");
        private readonly Guid classSubjectId8 = new Guid("a77bb839-07bc-47ba-b28b-e41fa355a35b");
        private readonly Guid classSubjectId9 = new Guid("686cf848-8cda-4791-85f7-43e25fb7db5c");
        private readonly Guid classSubjectId10 = new Guid("17cb3e61-7593-4a52-81ec-4b5db0d0489e");
        private readonly Guid classSubjectId11 = new Guid("bc8a83f2-18f7-44ad-ac60-cfe4ad601fdf");
        private readonly Guid classSubjectId12 = new Guid("f82b3dd9-3439-4d65-a000-10dd2128119c");
        private readonly Guid classSubjectId13 = new Guid("c8aefee3-2ce0-4d30-9278-214dbc2dbb17");
        private readonly Guid classSubjectId14 = new Guid("5c27a09c-3a37-421e-a0ce-b202444e1ce2");
        private readonly Guid classSubjectId15 = new Guid("ef57ba16-74a6-41a8-9066-193a91e9e34b");
        private readonly Guid classSubjectId16 = new Guid("bcf2b1ea-77ca-4159-b4b9-da052a285b0a");
        private readonly Guid classSubjectId17 = new Guid("74b1463d-8c0f-489b-b3bd-b551ee7341aa");
        private readonly Guid classSubjectId18 = new Guid("d9450901-d7bc-4cd3-b22c-80ea45717269");
        private readonly Guid classSubjectId19 = new Guid("48fde1ff-9b08-47d8-ae7b-635be6f0baef");
        private readonly Guid classSubjectId20 = new Guid("60e3c648-d922-413c-b82d-c6d6adde68a8");
        private readonly Guid classSubjectId21 = new Guid("15940a61-05bd-4aae-bdae-7b84776ddb9d");
        private readonly Guid classSubjectId22 = new Guid("fbb2a2a4-7b80-4f55-aff3-d2f6aeee8357");
        private readonly Guid classSubjectId23 = new Guid("907dddc1-f73b-43b2-92b2-66dd9a568c0f");
        private readonly Guid classSubjectId24 = new Guid("30bd9a53-d023-4bd1-9a40-496c7c53ffe8");
        private readonly Guid classSubjectId25 = new Guid("9bf39ddc-8e11-4424-8059-bbd2bfac9f27");
        private readonly Guid classSubjectId26 = new Guid("e85e931f-4f8a-470d-97e7-165fb016fa46");
        private readonly Guid classSubjectId27 = new Guid("a3b2767f-4549-45da-bc14-73841f9adebe");
        private readonly Guid classSubjectId28 = new Guid("e8c5516b-327b-44f2-95a7-89841b972afe");
        private readonly Guid classSubjectId29 = new Guid("829c3596-46a7-44e7-b656-546760543111");
        private readonly Guid classSubjectId30 = new Guid("e7ad8e52-02f8-4e0e-a93a-76c85434b931");
        private readonly Guid classSubjectId31 = new Guid("9a81a387-51f1-4cb3-a7da-5b7d4e4f2af4");
        private readonly Guid classSubjectId32 = new Guid("ffb6e551-a54b-4a89-9b89-00659e711f2e");
        private readonly Guid classSubjectId33 = new Guid("3e6e883c-ff6c-4b27-ae1f-6ff00b2ff0e3");
        private readonly Guid classSubjectId34 = new Guid("a10238c0-690f-4c51-aaaa-b4fc5c6a18fc");
        private readonly Guid classSubjectId35 = new Guid("4c76b425-dd0a-497b-b03c-4989458fa326");
        private readonly Guid classSubjectId36 = new Guid("2b6469fc-913e-4000-b51f-4d859d30e76f");
        private readonly Guid classSubjectId37 = new Guid("5b5f515f-8990-495d-b948-a4013494c365");
        private readonly Guid classSubjectId38 = new Guid("2426db38-658d-403f-8563-c83a07fded38");
        private readonly Guid classSubjectId39 = new Guid("ae08ca5f-b8c4-4aaa-b727-6080ac27122e");
        private readonly Guid classSubjectId40 = new Guid("63de929f-7148-4b46-ab1e-bbfac30a570f");
        private readonly Guid classSubjectId41 = new Guid("47e472bc-07c4-4350-b46c-839ebd7555d8");
        private readonly Guid classSubjectId42 = new Guid("4e80a7f7-d5a8-4fb2-a90e-cc53d6cc8d70");
        private readonly Guid classSubjectId43 = new Guid("c2620ffd-9aa0-4f8e-b5ed-1d4500d26212");
        private readonly Guid classSubjectId44 = new Guid("bac7468d-cf42-44f3-9291-da89bbc176fc");
        private readonly Guid classSubjectId45 = new Guid("5a1edab5-0341-4332-9580-9838d7d08b8b");
        private readonly Guid classSubjectId46 = new Guid("5672066b-b3d2-4360-8032-9f0b843bf9ca");
        private readonly Guid classSubjectId47 = new Guid("37e13020-b0f8-4172-8f56-8a000c27220b");
        private readonly Guid classSubjectId48 = new Guid("85cd8459-ffe4-4ac1-bde1-5de59aaf59e5");


        private readonly int academicYear = 2024;


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode1}' WHERE Id = '{classCategoryId1}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode2}' WHERE Id = '{classCategoryId2}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode3}' WHERE Id = '{classCategoryId3}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode4}' WHERE Id = '{classCategoryId4}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode5}' WHERE Id = '{classCategoryId5}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode6}' WHERE Id = '{classCategoryId6}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode7}' WHERE Id = '{classCategoryId7}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode8}' WHERE Id = '{classCategoryId8}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode9}' WHERE Id = '{classCategoryId9}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode10}' WHERE Id = '{classCategoryId10}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode11}' WHERE Id = '{classCategoryId11}' ");
            migrationBuilder.Sql($"UPDATE [User].[ClassCategory] SET Code = '{classCategoryCode12}' WHERE Id = '{classCategoryId12}' ");


            migrationBuilder.InsertData(
                schema: "User",
                table: "ClassSubject",
                columns: ["Id", "Code", "ClassCategoryId", "SubjectId", "AcademicYear"],
                values: new object[,]
                {
                    { classSubjectId1, $"{classCategoryCode1}-{subjectCode1}", classCategoryId1, subjectId1, academicYear },
                    { classSubjectId2, $"{classCategoryCode1}-{subjectCode2}", classCategoryId1, subjectId2, academicYear },
                    { classSubjectId3, $"{classCategoryCode1}-{subjectCode3}", classCategoryId1, subjectId3, academicYear },
                    { classSubjectId4, $"{classCategoryCode1}-{subjectCode4}", classCategoryId1, subjectId4, academicYear },
                    { classSubjectId5, $"{classCategoryCode2}-{subjectCode5}", classCategoryId2, subjectId5, academicYear },
                    { classSubjectId6, $"{classCategoryCode2}-{subjectCode6}", classCategoryId2, subjectId6, academicYear },
                    { classSubjectId7, $"{classCategoryCode2}-{subjectCode7}", classCategoryId2, subjectId7, academicYear },
                    { classSubjectId8, $"{classCategoryCode2}-{subjectCode8}", classCategoryId2, subjectId8, academicYear },

                    { classSubjectId9, $"{classCategoryCode3}-{subjectCode1}", classCategoryId3, subjectId1, academicYear },
                    { classSubjectId10, $"{classCategoryCode3}-{subjectCode2}", classCategoryId3, subjectId2, academicYear },
                    { classSubjectId11, $"{classCategoryCode3}-{subjectCode3}", classCategoryId3, subjectId3, academicYear },
                    { classSubjectId12, $"{classCategoryCode3}-{subjectCode4}", classCategoryId3, subjectId4, academicYear },
                    { classSubjectId13, $"{classCategoryCode4}-{subjectCode5}", classCategoryId4, subjectId5, academicYear },
                    { classSubjectId14, $"{classCategoryCode4}-{subjectCode6}", classCategoryId4, subjectId6, academicYear },
                    { classSubjectId15, $"{classCategoryCode4}-{subjectCode7}", classCategoryId4, subjectId7, academicYear },
                    { classSubjectId16, $"{classCategoryCode4}-{subjectCode8}", classCategoryId4, subjectId8, academicYear },

                    { classSubjectId17, $"{classCategoryCode5}-{subjectCode1}", classCategoryId5, subjectId1, academicYear },
                    { classSubjectId18, $"{classCategoryCode5}-{subjectCode2}", classCategoryId5, subjectId2, academicYear },
                    { classSubjectId19, $"{classCategoryCode5}-{subjectCode3}", classCategoryId5, subjectId3, academicYear },
                    { classSubjectId20, $"{classCategoryCode5}-{subjectCode4}", classCategoryId5, subjectId4, academicYear },
                    { classSubjectId21, $"{classCategoryCode6}-{subjectCode5}", classCategoryId6, subjectId5, academicYear },
                    { classSubjectId22, $"{classCategoryCode6}-{subjectCode6}", classCategoryId6, subjectId6, academicYear },
                    { classSubjectId23, $"{classCategoryCode6}-{subjectCode7}", classCategoryId6, subjectId7, academicYear },
                    { classSubjectId24, $"{classCategoryCode6}-{subjectCode8}", classCategoryId6, subjectId8, academicYear },

                    { classSubjectId25, $"{classCategoryCode7}-{subjectCode1}", classCategoryId7, subjectId1, academicYear },
                    { classSubjectId26, $"{classCategoryCode7}-{subjectCode2}", classCategoryId7, subjectId2, academicYear },
                    { classSubjectId27, $"{classCategoryCode7}-{subjectCode3}", classCategoryId7, subjectId3, academicYear },
                    { classSubjectId28, $"{classCategoryCode7}-{subjectCode4}", classCategoryId7, subjectId4, academicYear },
                    { classSubjectId29, $"{classCategoryCode8}-{subjectCode5}", classCategoryId8, subjectId5, academicYear },
                    { classSubjectId30, $"{classCategoryCode8}-{subjectCode6}", classCategoryId8, subjectId6, academicYear },
                    { classSubjectId31, $"{classCategoryCode8}-{subjectCode7}", classCategoryId8, subjectId7, academicYear },
                    { classSubjectId32, $"{classCategoryCode8}-{subjectCode8}", classCategoryId8, subjectId8, academicYear },

                    { classSubjectId33, $"{classCategoryCode9}-{subjectCode1}", classCategoryId9, subjectId1, academicYear },
                    { classSubjectId34, $"{classCategoryCode9}-{subjectCode2}", classCategoryId9, subjectId2, academicYear },
                    { classSubjectId35, $"{classCategoryCode9}-{subjectCode3}", classCategoryId9, subjectId3, academicYear },
                    { classSubjectId36, $"{classCategoryCode9}-{subjectCode4}", classCategoryId9, subjectId4, academicYear },
                    { classSubjectId37, $"{classCategoryCode10}-{subjectCode5}", classCategoryId10, subjectId5, academicYear },
                    { classSubjectId38, $"{classCategoryCode10}-{subjectCode6}", classCategoryId10, subjectId6, academicYear },
                    { classSubjectId39, $"{classCategoryCode10}-{subjectCode7}", classCategoryId10, subjectId7, academicYear },
                    { classSubjectId40, $"{classCategoryCode10}-{subjectCode8}", classCategoryId10, subjectId8, academicYear },

                    { classSubjectId41, $"{classCategoryCode11}-{subjectCode1}", classCategoryId11, subjectId1, academicYear },
                    { classSubjectId42, $"{classCategoryCode11}-{subjectCode2}", classCategoryId11, subjectId2, academicYear },
                    { classSubjectId43, $"{classCategoryCode11}-{subjectCode3}", classCategoryId11, subjectId3, academicYear },
                    { classSubjectId44, $"{classCategoryCode11}-{subjectCode4}", classCategoryId11, subjectId4, academicYear },
                    { classSubjectId45, $"{classCategoryCode12}-{subjectCode5}", classCategoryId12, subjectId5, academicYear },
                    { classSubjectId46, $"{classCategoryCode12}-{subjectCode6}", classCategoryId12, subjectId6, academicYear },
                    { classSubjectId47, $"{classCategoryCode12}-{subjectCode7}", classCategoryId12, subjectId7, academicYear },
                    { classSubjectId48, $"{classCategoryCode12}-{subjectCode8}", classCategoryId12, subjectId8, academicYear },
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
