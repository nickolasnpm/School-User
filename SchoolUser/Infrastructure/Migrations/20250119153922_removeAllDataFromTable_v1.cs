using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeAllDataFromTable_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [User].[AccessModule]");
            migrationBuilder.Sql("DELETE FROM [User].[RoleAccessModule]");
            migrationBuilder.Sql("DELETE FROM [User].[ClassCategory]");
            migrationBuilder.Sql("DELETE FROM [User].[Batch]");
            migrationBuilder.Sql("DELETE FROM [User].[ClassRank]");
            migrationBuilder.Sql("DELETE FROM [User].[ClassStream]");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
