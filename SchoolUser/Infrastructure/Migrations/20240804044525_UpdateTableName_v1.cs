using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateTableName_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassCategoryTable_BatchTable_BatchId",
                schema: "SchoolUser",
                table: "ClassCategoryTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassCategoryTable_ClassStreamTable_ClassStreamId",
                schema: "SchoolUser",
                table: "ClassCategoryTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectStudentTable_ClassSubjectTable_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectStudentTable_StudentTable_StudentId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectTable_ClassCategoryTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "ClassSubjectTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectTable_SubjectTable_SubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectTeacherTable_ClassSubjectTable_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectTeacherTable_TeacherTable_TeacherId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTable_ClassCategoryTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "StudentTable");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTable_UserTable_UserId",
                schema: "SchoolUser",
                table: "StudentTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherTable_ClassCategoryTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "TeacherTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherTable_UserTable_UserId",
                schema: "SchoolUser",
                table: "TeacherTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleTable_RoleTable_RoleId",
                schema: "SchoolUser",
                table: "UserRoleTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleTable_UserTable_UserId",
                schema: "SchoolUser",
                table: "UserRoleTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTable",
                schema: "SchoolUser",
                table: "UserTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleTable",
                schema: "SchoolUser",
                table: "UserRoleTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherTable",
                schema: "SchoolUser",
                table: "TeacherTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTable",
                schema: "SchoolUser",
                table: "SubjectTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTable",
                schema: "SchoolUser",
                table: "StudentTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleTable",
                schema: "SchoolUser",
                table: "RoleTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubjectTeacherTable",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubjectTable",
                schema: "SchoolUser",
                table: "ClassSubjectTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubjectStudentTable",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStreamTable",
                schema: "SchoolUser",
                table: "ClassStreamTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassCategoryTable",
                schema: "SchoolUser",
                table: "ClassCategoryTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatchTable",
                schema: "SchoolUser",
                table: "BatchTable");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.RenameTable(
                name: "UserTable",
                schema: "SchoolUser",
                newName: "User",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "UserRoleTable",
                schema: "SchoolUser",
                newName: "UserRole",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "TeacherTable",
                schema: "SchoolUser",
                newName: "Teacher",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "SubjectTable",
                schema: "SchoolUser",
                newName: "Subject",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "StudentTable",
                schema: "SchoolUser",
                newName: "Student",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "RoleTable",
                schema: "SchoolUser",
                newName: "Role",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "ClassSubjectTeacherTable",
                schema: "SchoolUser",
                newName: "ClassSubjectTeacher",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "ClassSubjectTable",
                schema: "SchoolUser",
                newName: "ClassSubject",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "ClassSubjectStudentTable",
                schema: "SchoolUser",
                newName: "ClassSubjectStudent",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "ClassStreamTable",
                schema: "SchoolUser",
                newName: "ClassStream",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "ClassCategoryTable",
                schema: "SchoolUser",
                newName: "ClassCategory",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "BatchTable",
                schema: "SchoolUser",
                newName: "Batch",
                newSchema: "User");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleTable_UserId",
                schema: "User",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleTable_RoleId",
                schema: "User",
                table: "UserRole",
                newName: "IX_UserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherTable_UserId",
                schema: "User",
                table: "Teacher",
                newName: "IX_Teacher_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherTable_ClassCategoryId",
                schema: "User",
                table: "Teacher",
                newName: "IX_Teacher_ClassCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentTable_UserId",
                schema: "User",
                table: "Student",
                newName: "IX_Student_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentTable_ClassCategoryId",
                schema: "User",
                table: "Student",
                newName: "IX_Student_ClassCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectTeacherTable_TeacherId",
                schema: "User",
                table: "ClassSubjectTeacher",
                newName: "IX_ClassSubjectTeacher_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectTeacherTable_ClassSubjectId",
                schema: "User",
                table: "ClassSubjectTeacher",
                newName: "IX_ClassSubjectTeacher_ClassSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectTable_SubjectId",
                schema: "User",
                table: "ClassSubject",
                newName: "IX_ClassSubject_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectTable_ClassCategoryId",
                schema: "User",
                table: "ClassSubject",
                newName: "IX_ClassSubject_ClassCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectStudentTable_StudentId",
                schema: "User",
                table: "ClassSubjectStudent",
                newName: "IX_ClassSubjectStudent_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectStudentTable_ClassSubjectId",
                schema: "User",
                table: "ClassSubjectStudent",
                newName: "IX_ClassSubjectStudent_ClassSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassCategoryTable_ClassStreamId",
                schema: "User",
                table: "ClassCategory",
                newName: "IX_ClassCategory_ClassStreamId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassCategoryTable_BatchId",
                schema: "User",
                table: "ClassCategory",
                newName: "IX_ClassCategory_BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                schema: "User",
                table: "UserRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                schema: "User",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                schema: "User",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                schema: "User",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "User",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubjectTeacher",
                schema: "User",
                table: "ClassSubjectTeacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubject",
                schema: "User",
                table: "ClassSubject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubjectStudent",
                schema: "User",
                table: "ClassSubjectStudent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStream",
                schema: "User",
                table: "ClassStream",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassCategory",
                schema: "User",
                table: "ClassCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batch",
                schema: "User",
                table: "Batch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassCategory_Batch_BatchId",
                schema: "User",
                table: "ClassCategory",
                column: "BatchId",
                principalSchema: "User",
                principalTable: "Batch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassCategory_ClassStream_ClassStreamId",
                schema: "User",
                table: "ClassCategory",
                column: "ClassStreamId",
                principalSchema: "User",
                principalTable: "ClassStream",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubject_ClassCategory_ClassCategoryId",
                schema: "User",
                table: "ClassSubject",
                column: "ClassCategoryId",
                principalSchema: "User",
                principalTable: "ClassCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubject_Subject_SubjectId",
                schema: "User",
                table: "ClassSubject",
                column: "SubjectId",
                principalSchema: "User",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectStudent_ClassSubject_ClassSubjectId",
                schema: "User",
                table: "ClassSubjectStudent",
                column: "ClassSubjectId",
                principalSchema: "User",
                principalTable: "ClassSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectStudent_Student_StudentId",
                schema: "User",
                table: "ClassSubjectStudent",
                column: "StudentId",
                principalSchema: "User",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectTeacher_ClassSubject_ClassSubjectId",
                schema: "User",
                table: "ClassSubjectTeacher",
                column: "ClassSubjectId",
                principalSchema: "User",
                principalTable: "ClassSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectTeacher_Teacher_TeacherId",
                schema: "User",
                table: "ClassSubjectTeacher",
                column: "TeacherId",
                principalSchema: "User",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassCategory_ClassCategoryId",
                schema: "User",
                table: "Student",
                column: "ClassCategoryId",
                principalSchema: "User",
                principalTable: "ClassCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserId",
                schema: "User",
                table: "Student",
                column: "UserId",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_ClassCategory_ClassCategoryId",
                schema: "User",
                table: "Teacher",
                column: "ClassCategoryId",
                principalSchema: "User",
                principalTable: "ClassCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_User_UserId",
                schema: "User",
                table: "Teacher",
                column: "UserId",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "User",
                table: "UserRole",
                column: "RoleId",
                principalSchema: "User",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "User",
                table: "UserRole",
                column: "UserId",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassCategory_Batch_BatchId",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassCategory_ClassStream_ClassStreamId",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubject_ClassCategory_ClassCategoryId",
                schema: "User",
                table: "ClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubject_Subject_SubjectId",
                schema: "User",
                table: "ClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectStudent_ClassSubject_ClassSubjectId",
                schema: "User",
                table: "ClassSubjectStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectStudent_Student_StudentId",
                schema: "User",
                table: "ClassSubjectStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectTeacher_ClassSubject_ClassSubjectId",
                schema: "User",
                table: "ClassSubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectTeacher_Teacher_TeacherId",
                schema: "User",
                table: "ClassSubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassCategory_ClassCategoryId",
                schema: "User",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserId",
                schema: "User",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_ClassCategory_ClassCategoryId",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_User_UserId",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "User",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "User",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                schema: "User",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                schema: "User",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                schema: "User",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                schema: "User",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "User",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubjectTeacher",
                schema: "User",
                table: "ClassSubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubjectStudent",
                schema: "User",
                table: "ClassSubjectStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubject",
                schema: "User",
                table: "ClassSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStream",
                schema: "User",
                table: "ClassStream");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassCategory",
                schema: "User",
                table: "ClassCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batch",
                schema: "User",
                table: "Batch");

            migrationBuilder.EnsureSchema(
                name: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "User",
                newName: "UserRoleTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "User",
                newName: "UserTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "Teacher",
                schema: "User",
                newName: "TeacherTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "Subject",
                schema: "User",
                newName: "SubjectTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "Student",
                schema: "User",
                newName: "StudentTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "User",
                newName: "RoleTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "ClassSubjectTeacher",
                schema: "User",
                newName: "ClassSubjectTeacherTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "ClassSubjectStudent",
                schema: "User",
                newName: "ClassSubjectStudentTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "ClassSubject",
                schema: "User",
                newName: "ClassSubjectTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "ClassStream",
                schema: "User",
                newName: "ClassStreamTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "ClassCategory",
                schema: "User",
                newName: "ClassCategoryTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameTable(
                name: "Batch",
                schema: "User",
                newName: "BatchTable",
                newSchema: "SchoolUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                schema: "SchoolUser",
                table: "UserRoleTable",
                newName: "IX_UserRoleTable_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleId",
                schema: "SchoolUser",
                table: "UserRoleTable",
                newName: "IX_UserRoleTable_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_UserId",
                schema: "SchoolUser",
                table: "TeacherTable",
                newName: "IX_TeacherTable_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_ClassCategoryId",
                schema: "SchoolUser",
                table: "TeacherTable",
                newName: "IX_TeacherTable_ClassCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_UserId",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "IX_StudentTable_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassCategoryId",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "IX_StudentTable_ClassCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectTeacher_TeacherId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                newName: "IX_ClassSubjectTeacherTable_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectTeacher_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                newName: "IX_ClassSubjectTeacherTable_ClassSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectStudent_StudentId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                newName: "IX_ClassSubjectStudentTable_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectStudent_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                newName: "IX_ClassSubjectStudentTable_ClassSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubject_SubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                newName: "IX_ClassSubjectTable_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubject_ClassCategoryId",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                newName: "IX_ClassSubjectTable_ClassCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassCategory_ClassStreamId",
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                newName: "IX_ClassCategoryTable_ClassStreamId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassCategory_BatchId",
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                newName: "IX_ClassCategoryTable_BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleTable",
                schema: "SchoolUser",
                table: "UserRoleTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTable",
                schema: "SchoolUser",
                table: "UserTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherTable",
                schema: "SchoolUser",
                table: "TeacherTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTable",
                schema: "SchoolUser",
                table: "SubjectTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTable",
                schema: "SchoolUser",
                table: "StudentTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleTable",
                schema: "SchoolUser",
                table: "RoleTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubjectTeacherTable",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubjectStudentTable",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubjectTable",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStreamTable",
                schema: "SchoolUser",
                table: "ClassStreamTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassCategoryTable",
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatchTable",
                schema: "SchoolUser",
                table: "BatchTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassCategoryTable_BatchTable_BatchId",
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                column: "BatchId",
                principalSchema: "SchoolUser",
                principalTable: "BatchTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassCategoryTable_ClassStreamTable_ClassStreamId",
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                column: "ClassStreamId",
                principalSchema: "SchoolUser",
                principalTable: "ClassStreamTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectStudentTable_ClassSubjectTable_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                column: "ClassSubjectId",
                principalSchema: "SchoolUser",
                principalTable: "ClassSubjectTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectStudentTable_StudentTable_StudentId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                column: "StudentId",
                principalSchema: "SchoolUser",
                principalTable: "StudentTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectTable_ClassCategoryTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                column: "ClassCategoryId",
                principalSchema: "SchoolUser",
                principalTable: "ClassCategoryTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectTable_SubjectTable_SubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                column: "SubjectId",
                principalSchema: "SchoolUser",
                principalTable: "SubjectTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectTeacherTable_ClassSubjectTable_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                column: "ClassSubjectId",
                principalSchema: "SchoolUser",
                principalTable: "ClassSubjectTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectTeacherTable_TeacherTable_TeacherId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                column: "TeacherId",
                principalSchema: "SchoolUser",
                principalTable: "TeacherTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTable_ClassCategoryTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "StudentTable",
                column: "ClassCategoryId",
                principalSchema: "SchoolUser",
                principalTable: "ClassCategoryTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTable_UserTable_UserId",
                schema: "SchoolUser",
                table: "StudentTable",
                column: "UserId",
                principalSchema: "SchoolUser",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherTable_ClassCategoryTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "TeacherTable",
                column: "ClassCategoryId",
                principalSchema: "SchoolUser",
                principalTable: "ClassCategoryTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherTable_UserTable_UserId",
                schema: "SchoolUser",
                table: "TeacherTable",
                column: "UserId",
                principalSchema: "SchoolUser",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleTable_RoleTable_RoleId",
                schema: "SchoolUser",
                table: "UserRoleTable",
                column: "RoleId",
                principalSchema: "SchoolUser",
                principalTable: "RoleTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleTable_UserTable_UserId",
                schema: "SchoolUser",
                table: "UserRoleTable",
                column: "UserId",
                principalSchema: "SchoolUser",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
