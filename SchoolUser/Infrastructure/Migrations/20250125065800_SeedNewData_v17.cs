using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(" UPDATE [User].[User] SET Gender = 'Male' WHERE Gender = 'male' ");
            migrationBuilder.Sql(" UPDATE [User].[User] SET Gender = 'Female' WHERE Gender = 'female' ");

            migrationBuilder.Sql(" UPDATE [User].[Role] SET Title = 'Student' WHERE Title = 'student' ");
            migrationBuilder.Sql(" UPDATE [User].[Role] SET Title = 'Teacher' WHERE Title = 'teacher' ");
            migrationBuilder.Sql(" UPDATE [User].[Role] SET Title = 'Admin' WHERE Title = 'admin' ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
