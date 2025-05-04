using SchoolUser.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolUser.Infrastructure.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        #region User
        public DbSet<User>? User { get; set; }
        public DbSet<Role>? Role { get; set; }
        public DbSet<UserRole>? UserRole { get; set; }
        public DbSet<Student>? Student { get; set; }
        public DbSet<Teacher>? Teacher { get; set; }
        public DbSet<AccessModule>? AccessModule { get; set; }
        public DbSet<RoleAccessModule>? RoleAccessModule { get; set; }
        #endregion

        #region School
        public DbSet<Batch>? Batch { get; set; }
        public DbSet<ClassStream>? ClassStream { get; set; }
        public DbSet<ClassRank>? ClassRank { get; set; }
        public DbSet<ClassCategory>? ClassCategory { get; set; }
        public DbSet<Subject>? Subject { get; set; }
        public DbSet<ClassSubject>? ClassSubject { get; set; }
        public DbSet<ClassSubjectTeacher>? ClassSubjectTeacher { get; set; }
        public DbSet<ClassSubjectStudent>? ClassSubjectStudent { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SetTableSchema<User>("User", modelBuilder);
            SetTableSchema<Role>("Role", modelBuilder);
            SetTableSchema<UserRole>("UserRole", modelBuilder);
            SetTableSchema<Student>("Student", modelBuilder);
            SetTableSchema<Teacher>("Teacher", modelBuilder);
            SetTableSchema<AccessModule>("AccessModule", modelBuilder);
            SetTableSchema<RoleAccessModule>("RoleAccessModule", modelBuilder);
            SetTableSchema<Batch>("Batch", modelBuilder);
            SetTableSchema<ClassStream>("ClassStream", modelBuilder);
            SetTableSchema<ClassRank>("ClassRank", modelBuilder);
            SetTableSchema<ClassCategory>("ClassCategory", modelBuilder);
            SetTableSchema<Subject>("Subject", modelBuilder);
            SetTableSchema<ClassSubject>("ClassSubject", modelBuilder);
            SetTableSchema<ClassSubjectTeacher>("ClassSubjectTeacher", modelBuilder);
            SetTableSchema<ClassSubjectStudent>("ClassSubjectStudent", modelBuilder);

            // ClassCategory - Batch
            modelBuilder.Entity<ClassCategory>()
                .HasOne(cc => cc.Batch)
                .WithMany(b => b.ClassCategories)
                .HasForeignKey(cc => cc.BatchId);

            // ClassCategory - ClassStream
            modelBuilder.Entity<ClassCategory>()
                .HasOne(cc => cc.ClassStream)
                .WithMany(ss => ss.ClassCategories)
                .HasForeignKey(cc => cc.ClassStreamId);

            // ClassCategory - ClassRank
            modelBuilder.Entity<ClassCategory>()
                .HasOne(cc => cc.ClassRank)
                .WithMany(ct => ct.ClassCategories)
                .HasForeignKey(cc => cc.ClassRankId);

            // ClassCategory - Student
            modelBuilder.Entity<ClassCategory>()
                .HasMany(cc => cc.Students)
                .WithOne(s => s.ClassCategory)
                .HasForeignKey(s => s.ClassCategoryId)
                .OnDelete(DeleteBehavior.SetNull); ;

            // ClassCategory - Teacher
            modelBuilder.Entity<ClassCategory>()
                .HasMany(cc => cc.Teachers)
                .WithOne(t => t.ClassCategory)
                .HasForeignKey(t => t.ClassCategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Subject - ClassSubject - ClassCategory
            modelBuilder.Entity<ClassSubject>()
                .HasOne(cc => cc.Subject)
                .WithMany(s => s.ClassSubjects)
                .HasForeignKey(cs => cs.SubjectId);

            // ClassCategory - ClassSubject - Subject
            modelBuilder.Entity<ClassSubject>()
                .HasOne(cc => cc.ClassCategory)
                .WithMany(s => s.ClassSubjects)
                .HasForeignKey(cs => cs.ClassCategoryId);

            // ClassSubject - ClassSubjectTeacher - Teacher
            modelBuilder.Entity<ClassSubjectTeacher>()
                .HasOne(cst => cst.ClassSubject)
                .WithMany(cs => cs.ClassSubjectTeachers)
                .HasForeignKey(cst => cst.ClassSubjectId);

            // Teacher - ClassSubjectTeacher - ClassSubject
            modelBuilder.Entity<ClassSubjectTeacher>()
                .HasOne(cst => cst.Teacher)
                .WithMany(t => t.ClassSubjectTeachers)
                .HasForeignKey(cst => cst.TeacherId);

            // ClassSubject - ClassSubjectStudent - Student
            modelBuilder.Entity<ClassSubjectStudent>()
                .HasOne(css => css.ClassSubject)
                .WithMany(s => s.ClassSubjectStudents)
                .HasForeignKey(css => css.ClassSubjectId);

            // Student - ClassSubjectStudent - ClassSubject 
            modelBuilder.Entity<ClassSubjectStudent>()
                .HasOne(css => css.Student)
                .WithMany(s => s.ClassSubjectStudents)
                .HasForeignKey(css => css.StudentId);

            // User - Student
            modelBuilder.Entity<User>()
                .HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId);

            // User - Teacher
            modelBuilder.Entity<User>()
                .HasOne(u => u.Teacher)
                .WithOne(t => t.User)
                .HasForeignKey<Teacher>(t => t.UserId);

            // User - UserRole - Role
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            // Role - UserRole - User
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // AccessModule - RoleAccessModule - Role 
            modelBuilder.Entity<RoleAccessModule>()
                .HasOne(ram => ram.AccessModule)
                .WithMany(am => am.RoleAccessModules)
                .HasForeignKey(ram => ram.AccessModuleId);

            // Role - RoleAccessModule - AccessModule 
            modelBuilder.Entity<RoleAccessModule>()
                .HasOne(ram => ram.Role)
                .WithMany(r => r.RoleAccessModules)
                .HasForeignKey(ram => ram.RoleId);

        }

        private void SetTableSchema<T>(string tableName, ModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>().ToTable(tableName, "User");
        }
    }
}