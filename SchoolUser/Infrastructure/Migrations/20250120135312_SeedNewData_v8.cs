using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update Students
            migrationBuilder.Sql(
                "WITH StudentSequence AS (" +
                "   SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS seq " +
                "   FROM [User].[User] " +
                "   WHERE FullName LIKE '%Student%'" +
                ") " +
                "UPDATE [User].[User] " +
                "SET SerialTag = CONCAT('S', RIGHT('000000' + CAST(seq AS VARCHAR), 6)) " +
                "FROM StudentSequence " +
                "WHERE [User].[User].Id = StudentSequence.Id;"
            );

            // Update Teachers
            migrationBuilder.Sql(
                "WITH TeacherSequence AS (" +
                "   SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS seq " +
                "   FROM [User].[User] " +
                "   WHERE FullName LIKE '%Teacher%'" +
                ") " +
                "UPDATE [User].[User] " +
                "SET SerialTag = CONCAT('T', RIGHT('000000' + CAST(seq AS VARCHAR), 6)) " +
                "FROM TeacherSequence " +
                "WHERE [User].[User].Id = TeacherSequence.Id;"
            );

            // Update Teachers
            migrationBuilder.Sql(
                "WITH AdminSequence AS (" +
                "   SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS seq " +
                "   FROM [User].[User] " +
                "   WHERE FullName LIKE '%Admin%'" +
                ") " +
                "UPDATE [User].[User] " +
                "SET SerialTag = CONCAT('A', RIGHT('000000' + CAST(seq AS VARCHAR), 6)) " +
                "FROM AdminSequence " +
                "WHERE [User].[User].Id = AdminSequence.Id;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Optionally, you can reverse the changes made in the Up method.
            migrationBuilder.Sql("UPDATE [User].[User] SET SerialTag = NULL WHERE SerialTag IS NOT NULL;");
        }
    }
}
