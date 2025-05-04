using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v15 : Migration
    {

        #region Student
        private readonly Guid studentId1 = new Guid("aca69ac4-2bd2-4d9b-b84f-56a0793d9f40");
        private readonly Guid studentId2 = new Guid("7f588c68-3fa5-4fbf-b9af-a21f1656c957");
        private readonly Guid studentId3 = new Guid("6e1ec7d1-8311-410d-850a-9cbdaf598728");
        private readonly Guid studentId4 = new Guid("692c94cf-fb77-43a8-a0ff-734770cf5078");
        private readonly Guid studentId5 = new Guid("5162685a-869f-49d5-8d8a-6956f032344d");
        private readonly Guid studentId6 = new Guid("7bf293b0-b5b6-4538-b0dc-80479d473c3e");
        private readonly Guid studentId7 = new Guid("46b55249-3dba-4ca7-8786-75c12bc9a5c9");
        private readonly Guid studentId8 = new Guid("077875b7-5198-41e1-b3b7-d3345b8c82f2");
        private readonly Guid studentId9 = new Guid("23ee9929-0324-47b1-979e-cb8a334bd8c9");
        private readonly Guid studentId10 = new Guid("984af5e6-48b8-4396-a2a3-ec4ae7015062");
        private readonly Guid studentId11 = new Guid("b6a95766-3422-4ede-920a-eee089028323");
        private readonly Guid studentId12 = new Guid("e97266a3-c160-448e-a1b9-985bef7385dd");
        private readonly Guid studentId13 = new Guid("500a3272-daf2-41a0-afe1-06e50bb7dbb2");
        private readonly Guid studentId14 = new Guid("67da72fb-74fc-4dcc-b817-feee349eb68a");
        private readonly Guid studentId15 = new Guid("19d39def-272a-4cc3-bbc0-b62b95b504c4");
        private readonly Guid studentId16 = new Guid("00fab99e-3c20-4b31-b52d-ab3dce9087d5");
        private readonly Guid studentId17 = new Guid("b8461da6-29cf-40f8-aef7-41fb547b180f");
        private readonly Guid studentId18 = new Guid("89d27a99-96ce-4798-96c9-8b3693b4396d");
        private readonly Guid studentId19 = new Guid("21504568-db0b-4585-8571-61fb45e7a591");
        private readonly Guid studentId20 = new Guid("8b57255a-25fa-4271-ac00-b113b3f5a075");
        private readonly Guid studentId21 = new Guid("01c21eae-856c-44cc-a70c-4e45c17e4e9c");
        private readonly Guid studentId22 = new Guid("a3c8e25b-b512-434b-8fa3-0e66ffa41c2c");
        private readonly Guid studentId23 = new Guid("fe003217-07db-4f75-8cb5-1502a080eed4");
        private readonly Guid studentId24 = new Guid("a38bf59f-bea4-454f-8467-2b253087c319");
        private readonly Guid studentId25 = new Guid("b756d61f-eac9-4fbd-bfd0-256e86b803b6");
        private readonly Guid studentId26 = new Guid("8144c05d-0eee-4135-97c0-a67271de0379");
        private readonly Guid studentId27 = new Guid("a841a47c-7a8f-4d57-9323-f2e88a3801bc");
        private readonly Guid studentId28 = new Guid("4098aebd-284e-4d6d-b321-c773eb564a06");
        private readonly Guid studentId29 = new Guid("ba2113ba-15d1-4f60-bd05-76e53606204b");
        private readonly Guid studentId30 = new Guid("3d8b6dd9-d316-4c0c-a162-43d4e7d37f87");
        private readonly Guid studentId31 = new Guid("a36998d9-2d64-403d-8010-f85a1e223234");
        private readonly Guid studentId32 = new Guid("7edbb423-f7d8-42ea-9457-e161b73e2bb7");
        private readonly Guid studentId33 = new Guid("67351ad7-7cbf-4bfa-b786-f0ee9039b9f8");
        private readonly Guid studentId34 = new Guid("b613f2bd-af52-43a3-9b92-da5f88d53481");
        private readonly Guid studentId35 = new Guid("f6526308-8de0-4f68-bca3-84e4fc72a1b6");
        private readonly Guid studentId36 = new Guid("5c9b57aa-3fd1-4eda-8707-289dee52ce74");
        private readonly Guid studentId37 = new Guid("178e6f7c-a8e0-4f81-9c4e-5d6f565082e3");
        private readonly Guid studentId38 = new Guid("67e57dd9-0a7b-41c0-bf18-d75247ec3e9e");
        private readonly Guid studentId39 = new Guid("53bbdbb2-a8f9-4277-bde5-8fe312def5df");
        private readonly Guid studentId40 = new Guid("3616fb89-0ce7-4959-a9d7-13aea5f0b6b4");
        private readonly Guid studentId41 = new Guid("7026fdf8-9a5c-41db-a206-90181ac2d0fa");
        private readonly Guid studentId42 = new Guid("afb29af0-d2af-4c26-9fde-2f603c785fdb");
        private readonly Guid studentId43 = new Guid("7479d023-f07f-4439-bd10-f8e0a580b030");
        private readonly Guid studentId44 = new Guid("fd873b40-10a4-40bb-9a0f-1fbdc6e7c9be");
        private readonly Guid studentId45 = new Guid("2b55b5ce-b5dd-4f98-8a7e-f81eed04ea58");
        private readonly Guid studentId46 = new Guid("bbbb868c-5041-43ce-a83a-6d098531aeb9");
        private readonly Guid studentId47 = new Guid("ce00edbb-2403-41f5-b4d1-05c374421381");
        private readonly Guid studentId48 = new Guid("1c53824a-5263-4b56-a114-520090f99378");
        private readonly Guid studentId49 = new Guid("7ae99302-dfc6-49b9-b4bd-17960ea77d83");
        private readonly Guid studentId50 = new Guid("43c6ecce-a7ad-4477-8a91-8bd45b2f55b2");
        private readonly Guid studentId51 = new Guid("59e69c5a-0fef-445d-bb43-f29a024a2c3b");
        private readonly Guid studentId52 = new Guid("255fc014-878d-4cac-abd0-8947be6bb8ec");
        private readonly Guid studentId53 = new Guid("5f690c82-1771-4931-be84-0833d67b9a35");
        private readonly Guid studentId54 = new Guid("c15fb460-efa6-4582-af21-a1651fd6d14f");
        private readonly Guid studentId55 = new Guid("39daaf9f-d650-456d-97e1-8fe5186059eb");
        private readonly Guid studentId56 = new Guid("796ae0df-8485-41cd-b3cf-431f1fc138b4");
        private readonly Guid studentId57 = new Guid("eb2f86c7-e5d3-4919-bf3b-0ec90faca990");
        private readonly Guid studentId58 = new Guid("a7521676-f3a8-47cb-acef-d67df115d281");
        private readonly Guid studentId59 = new Guid("ec8265e8-c976-441f-a648-e90738eb334b");
        private readonly Guid studentId60 = new Guid("41968e63-3e0c-45f6-9b33-8c2943b6209f");
        #endregion


        #region ClassCategoryId
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
        #endregion

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId12}' WHERE Id = '{studentId1}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId12}' WHERE Id = '{studentId2}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId12}' WHERE Id = '{studentId3}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId12}' WHERE Id = '{studentId4}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId12}' WHERE Id = '{studentId5}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId11}' WHERE Id = '{studentId6}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId11}' WHERE Id = '{studentId7}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId11}' WHERE Id = '{studentId8}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId11}' WHERE Id = '{studentId9}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId11}' WHERE Id = '{studentId10}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId10}' WHERE Id = '{studentId11}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId10}' WHERE Id = '{studentId12}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId10}' WHERE Id = '{studentId13}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId10}' WHERE Id = '{studentId14}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId10}' WHERE Id = '{studentId15}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId9}' WHERE Id = '{studentId16}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId9}' WHERE Id = '{studentId17}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId9}' WHERE Id = '{studentId18}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId9}' WHERE Id = '{studentId19}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId9}' WHERE Id = '{studentId20}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId8}' WHERE Id = '{studentId21}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId8}' WHERE Id = '{studentId22}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId8}' WHERE Id = '{studentId23}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId8}' WHERE Id = '{studentId24}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId8}' WHERE Id = '{studentId25}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId7}' WHERE Id = '{studentId26}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId7}' WHERE Id = '{studentId27}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId7}' WHERE Id = '{studentId28}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId7}' WHERE Id = '{studentId29}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId7}' WHERE Id = '{studentId30}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId6}' WHERE Id = '{studentId31}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId6}' WHERE Id = '{studentId32}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId6}' WHERE Id = '{studentId33}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId6}' WHERE Id = '{studentId34}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId6}' WHERE Id = '{studentId35}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId5}' WHERE Id = '{studentId36}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId5}' WHERE Id = '{studentId37}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId5}' WHERE Id = '{studentId38}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId5}' WHERE Id = '{studentId39}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId5}' WHERE Id = '{studentId40}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId4}' WHERE Id = '{studentId41}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId4}' WHERE Id = '{studentId42}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId4}' WHERE Id = '{studentId43}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId4}' WHERE Id = '{studentId44}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId4}' WHERE Id = '{studentId45}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId3}' WHERE Id = '{studentId46}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId3}' WHERE Id = '{studentId47}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId3}' WHERE Id = '{studentId48}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId3}' WHERE Id = '{studentId49}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId3}' WHERE Id = '{studentId50}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId2}' WHERE Id = '{studentId51}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId2}' WHERE Id = '{studentId52}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId2}' WHERE Id = '{studentId53}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId2}' WHERE Id = '{studentId54}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId2}' WHERE Id = '{studentId55}' ");

            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId1}' WHERE Id = '{studentId56}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId1}' WHERE Id = '{studentId57}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId1}' WHERE Id = '{studentId58}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId1}' WHERE Id = '{studentId59}' ");
            migrationBuilder.Sql($"UPDATE [User].[Student] SET ClassCategoryId = '{classCategoryId1}' WHERE Id = '{studentId60}' ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
