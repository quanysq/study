using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EFCodeFirstExample.Models;

namespace EFCodeFirstExample.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // 阻止复数表名称。
            // 如果未执行此操作，则数据库中生成的表将被命名为 Students、Courses和 Enrollments。
            // 相反，表名称将为 Student、Course和 Enrollment
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // 使用 Fluent API 配置 Instructor 和 Course 多对多关系
            // 代码指定联接表的表和列名
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                           .MapRightKey("InstructorID")
                           .ToTable("CourseInstructor"));
        }
    }
}