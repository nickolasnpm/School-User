using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v11 : Migration
    {
        private readonly Guid classRankId1 = new Guid("4feaafb2-a22e-49e0-886b-18465c20e3a6");
        private readonly Guid classRankId2 = new Guid("50912890-6ce4-48b7-9bbe-01d377d72b6b");
        private readonly Guid classRankId3 = new Guid("635ee98a-2cb4-45d9-956b-6900f6cc81b4");
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                           schema: "User",
                           table: "ClassStream",
                           keyColumn: "Id",
                           keyValues: new object[]
                           {
                                classRankId1, classRankId2, classRankId3
                           });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
