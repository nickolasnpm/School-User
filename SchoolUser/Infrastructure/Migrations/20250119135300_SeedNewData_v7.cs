using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v7 : Migration
    {
        Guid classRankId = Guid.NewGuid();

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [User].[Batch] SET Name = 'First', Code = '1' WHERE Id = '2D1E3E91-CE0E-4E51-9C49-6C39FF4D9C16' ");
            migrationBuilder.Sql("UPDATE [User].[Batch] SET Name = 'Second', Code = '2' WHERE Id = '44E8D76A-CA78-4AB0-94A7-830D7CD37256' ");
            migrationBuilder.Sql("UPDATE [User].[Batch] SET Name = 'Third', Code = '3' WHERE Id = '4ED1EBDB-BEE1-46C8-8DA3-E620C4BF12D7' ");
            migrationBuilder.Sql("UPDATE [User].[Batch] SET Name = 'Fourth', Code = '4' WHERE Id = 'DEBF4CB9-AF2A-46B6-9EA5-4681486B532A' ");
            migrationBuilder.Sql("UPDATE [User].[Batch] SET Name = 'Fifth', Code = '5' WHERE Id = '9BE8C650-13ED-43B7-8F70-F0D8C52BB7B9' ");
            migrationBuilder.Sql("UPDATE [User].[Batch] SET Name = 'Sixth', Code = '6' WHERE Id = 'F1EFB34E-0A51-42E7-8C15-02AD452F555D' ");
            migrationBuilder.Sql("UPDATE [User].[Batch] SET Code = 'OOS', IsActive = 1 WHERE Id = '58B02409-AF73-4FC0-9C35-B586ED997E63' ");

            migrationBuilder.Sql("UPDATE [User].[ClassStream] SET Code = 'SNT' WHERE Name = 'Science' ");
            migrationBuilder.Sql("UPDATE [User].[ClassStream] SET Code = 'ART' WHERE Name = 'Art' ");
            migrationBuilder.Sql("UPDATE [User].[ClassStream] SET IsActive = 1 WHERE Name = 'NONE' ");

            migrationBuilder.Sql("UPDATE [User].[ClassRank] SET Name = 'First', Code = 'A' WHERE Id = '64227710-0EA6-4270-B14B-35EB3312F372' ");
            migrationBuilder.Sql("INSERT INTO [User].[ClassRank] (Id, Name, Code, IsActive) VALUES ('8b50a3f0-1733-4fc2-9b04-918bbc5126d6', 'Second', 'B', 1) ");
            migrationBuilder.Sql("INSERT INTO [User].[ClassRank] (Id, Name, Code, IsActive) VALUES ('8dd62120-49ac-4b60-958e-bb3befb0357c', 'NONE', 'NN', 1) ");

            migrationBuilder.Sql("DELETE [User].[ClassCategory] WHERE Id = 'AB9D56FB-F773-4A98-9FF0-0C82D8CB6FEE' ");
            migrationBuilder.Sql("DELETE [User].[ClassCategory] WHERE Id = 'CB119B6F-6F59-4685-A439-9A8443DDBCE9' ");
            migrationBuilder.Sql("UPDATE [User].[ClassCategory] SET Code = 'OOS-NN-NN', ClassRankId = '8dd62120-49ac-4b60-958e-bb3befb0357c'  WHERE Id = '11D74D9B-A4AD-4623-9A32-B06002118487' ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
