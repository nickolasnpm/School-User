using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v16 : Migration
    {

        #region Teacher
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
            migrationBuilder.Sql(" UPDATE [User].[Teacher] SET IsActive = 1 ");
            migrationBuilder.Sql(" UPDATE [User].[Teacher] SET ServiceStatus = 'Permanent' ");

            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId1}' WHERE Id = '{teacherId1}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId2}' WHERE Id = '{teacherId2}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId3}' WHERE Id = '{teacherId3}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId4}' WHERE Id = '{teacherId4}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId5}' WHERE Id = '{teacherId5}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId6}' WHERE Id = '{teacherId6}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId7}' WHERE Id = '{teacherId7}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId8}' WHERE Id = '{teacherId8}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId9}' WHERE Id = '{teacherId9}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId10}' WHERE Id = '{teacherId10}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId11}' WHERE Id = '{teacherId11}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ClassCategoryId = '{classCategoryId12}' WHERE Id = '{teacherId12}' ");

            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Batch', ResponsibilityFocus = 'First' WHERE Id = '{teacherId1}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Batch', ResponsibilityFocus = 'Second' WHERE Id = '{teacherId2}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Batch', ResponsibilityFocus = 'Third' WHERE Id = '{teacherId3}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Batch', ResponsibilityFocus = 'Fourth' WHERE Id = '{teacherId4}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Batch', ResponsibilityFocus = 'Fifth' WHERE Id = '{teacherId5}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Batch', ResponsibilityFocus = 'Sixth' WHERE Id = '{teacherId6}' ");

            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'Malay' WHERE Id = '{teacherId7}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'English' WHERE Id = '{teacherId8}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'Mandarin' WHERE Id = '{teacherId9}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'Tamil' WHERE Id = '{teacherId10}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'Mathematic' WHERE Id = '{teacherId11}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'Biology' WHERE Id = '{teacherId12}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'Chemistry' WHERE Id = '{teacherId13}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'Subject', ResponsibilityFocus = 'Physic' WHERE Id = '{teacherId14}' ");

            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'School', ResponsibilityFocus = 'Batch' WHERE Id = '{teacherId15}' ");
            migrationBuilder.Sql($" UPDATE [User].[Teacher] SET ResponsibilityType = 'School', ResponsibilityFocus = 'Subject' WHERE Id = '{teacherId16}' ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
