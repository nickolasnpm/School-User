using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateDataValue_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [User].[Student] SET [IsActive] = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [User].[Student] SET [IsActive] = 0");
        }
    }
}
