﻿using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolUser.Domain.Models;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class SeedNewData_v3 : Migration
    {
        private readonly string _pepper = "PasswordHashSaltPepperIterationForSchoolManagementSystemPortal";
        private readonly int _iteration = 3;
        private string randomPassword = "1234qwerASDF_";

        Guid UserId = new Guid("ec6b3773-9886-416e-8563-eceea294fd47");
        Guid roleId = new Guid("4a23cdcc-c914-485e-9168-44ad84624ec9");
        Guid UserRoleId = new Guid("9e5a45aa-28d6-41b5-9854-e9a0231fc6e0");

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region UserCreation

            var user = new User
            {
                SerialTag = "1001",
                FullName = "Nickolas Admin",
                EmailAddress = "nickolaspiusmatu@outlook.com",
                Id = UserId,
                IsConfirmedEmail = true,
                MobileNumber = "0123456789",
                BirthDate = "1996-02-10",
                Age = 28,
                Gender = "male",
                PasswordSalt = "",
                PasswordHash = "",
                VerificationNumber = "",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "",
                UpdatedAt = DateTime.Now,
                UpdatedBy = ""
            };

            #region generateSalt
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            user.PasswordSalt = Convert.ToBase64String(byteSalt);
            #endregion

            #region generateHash
            for (int j = 0; j < _iteration; j++)
            {
                using var sha256 = SHA256.Create();
                var passwordSaltPepper = $"{randomPassword}{user.PasswordSalt}{_pepper}";
                var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
                var byteHash = sha256.ComputeHash(byteValue);
                randomPassword = Convert.ToBase64String(byteHash);
            }

            user.PasswordHash = randomPassword;
            #endregion

            user.VerificationNumber = "123456";
            user.VerificationExpiration = DateTime.Now.AddHours(48);
            user.TokenExpiration = DateTime.Now;
            user.CreatedBy = "Initial Data Seeding";
            user.CreatedAt = DateTime.Now;

            #endregion

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "UserTable",
                columns: new[] { "Id", "FullName", "EmailAddress", "IsConfirmedEmail", "MobileNumber", "BirthDate", "Gender", "Age", "PasswordSalt", "PasswordHash", "VerificationNumber", "VerificationExpiration", "AccessToken", "RefreshToken", "TokenExpiration", "CreatedBy", "CreatedAt" },
                values: new object[,]
                {
                    { user.Id, user.FullName, user.EmailAddress, user.IsConfirmedEmail, user.MobileNumber, user.BirthDate, user.Gender, user.Age, user.PasswordSalt, user.PasswordHash, user.VerificationNumber, user.VerificationExpiration, user.AccessToken, user.RefreshToken, user.TokenExpiration, user.CreatedBy, user.CreatedAt },
                });

            migrationBuilder.InsertData(
               schema: "SchoolUser",
               table: "RoleTable",
               columns: new[] { "Id", "Title" },
               values: new object[,]
               {
                    { roleId, "admin" },
               });

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "UserRoleTable",
                columns: new[] { "Id", "UserId", "RoleId" },
                values: new object[,]
                {
                    { UserRoleId, UserId, roleId },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "UserRoleTable", keyColumn: "Id", keyValues: new object[]
            {
                UserRoleId
            });

            migrationBuilder.DeleteData(schema: "SchoolUser", table: "RoleTable", keyColumn: "Id", keyValues: new object[]
            {
                roleId
            });

            migrationBuilder.DeleteData(schema: "SchoolUser", table: "UserTable", keyColumn: "Id", keyValues: new object[]
            {
                UserId
            });
        }
    }
}
