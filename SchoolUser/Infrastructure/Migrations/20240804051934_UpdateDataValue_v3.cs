using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateDataValue_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [User].[Batch] SET [isActive] = 1 WHERE [Name] IN ('1', '2', '3', '4', '5', '6')");
            migrationBuilder.Sql("UPDATE [User].[ClassStream] SET [isActive] = 1 WHERE [Name] IN ('Art', 'Science')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [User].[Batch] SET [isActive] = 0 WHERE [Name] IN ('1', '2', '3', '4', '5', '6')");
            migrationBuilder.Sql("UPDATE [User].[ClassStream] SET [isActive] = 0 WHERE [Name] IN ('Art', 'Science')");
        }
    }
}
