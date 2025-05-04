using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v18 : Migration
    {
        private readonly Guid teacherId1 = new Guid("09458a6c-d313-4bee-b66f-19c0ff543c44");
        private readonly Guid teacherId2 = new Guid("0218e6c6-9b1c-44c3-9ac2-95b2fda929f7");
        private readonly Guid teacherId3 = new Guid("77a14da8-1caa-4ad0-9cd3-4208cfc3ac66");
        private readonly Guid teacherId4 = new Guid("39b703bc-9cc0-4974-be21-cf4327e9f6b4");
        private readonly Guid teacherId5 = new Guid("953785b4-12d2-4ca0-a65e-70230c5880c5");
        private readonly Guid teacherId6 = new Guid("8bc1831c-1c7f-4a43-a04b-3aae0a7bfe7d");
        private readonly Guid teacherId7 = new Guid("5d6e3425-d473-47e0-b20d-6ac256c1baa9");
        private readonly Guid teacherId8 = new Guid("8b1f6bae-fe3e-4cca-9bfa-6ff4856bf790");
        private readonly Guid teacherId9 = new Guid("d455d687-5783-490c-abf3-92ea550fb2f6");
        private readonly Guid teacherId10 = new Guid("a5649831-2968-4985-a3d2-08025ec365a6");
        private readonly Guid teacherId11 = new Guid("62d4224a-f21d-4adc-9826-e12ed32af95e");
        private readonly Guid teacherId12 = new Guid("29861f16-863d-415d-9965-8f0ac0dbb0d7");
        private readonly Guid teacherId13 = new Guid("6c96331c-aa01-47e6-9aa7-9ebe3d23a527");
        private readonly Guid teacherId14 = new Guid("70b43a46-90a4-4154-a977-9de8cb3d6464");
        private readonly Guid teacherId15 = new Guid("507b51fa-905f-4d00-a6df-f1c68608c3a4");
        private readonly Guid teacherId16 = new Guid("148b8e31-7684-4974-bde4-744c9171f606");

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($" UPDATE [User].[Batch] SET TeacherId = '{teacherId1}' WHERE Name = 'First' ");
            migrationBuilder.Sql($" UPDATE [User].[Batch] SET TeacherId = '{teacherId2}' WHERE Name = 'Second' ");
            migrationBuilder.Sql($" UPDATE [User].[Batch] SET TeacherId = '{teacherId3}' WHERE Name = 'Third' ");
            migrationBuilder.Sql($" UPDATE [User].[Batch] SET TeacherId = '{teacherId4}' WHERE Name = 'Fourth' ");
            migrationBuilder.Sql($" UPDATE [User].[Batch] SET TeacherId = '{teacherId5}' WHERE Name = 'Fifth' ");
            migrationBuilder.Sql($" UPDATE [User].[Batch] SET TeacherId = '{teacherId6}' WHERE Name = 'Sixth' ");

            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId7}' WHERE Name = 'Malay' ");
            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId8}' WHERE Name = 'English' ");
            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId9}' WHERE Name = 'Mandarin' ");
            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId10}' WHERE Name = 'Tamil' ");
            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId11}' WHERE Name = 'Mathematic' ");
            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId12}' WHERE Name = 'Biology' ");
            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId13}' WHERE Name = 'Chemistry' ");
            migrationBuilder.Sql($" UPDATE [User].[Subject] SET TeacherId = '{teacherId14}' WHERE Name = 'Physic' ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
