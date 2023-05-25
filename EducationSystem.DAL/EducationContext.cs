using EducationSystem.DAL.Mapping;
using EducationSystem.DAL.Migrations;
using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL
{
    public class EducationContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new BranchMapping());
            modelBuilder.Configurations.Add(new ClassesMapping());
            modelBuilder.Configurations.Add(new CourseMapping());
            modelBuilder.Configurations.Add(new StudentMapping());
            modelBuilder.Configurations.Add(new StudentPollMapping());
            modelBuilder.Configurations.Add(new UserRoleMapping());

            base.OnModelCreating(modelBuilder);
        }

        public EducationContext()
        {
            var file = Directory.GetCurrentDirectory();
            var path = Path.Combine(file, "EducationSystem.mdf");
            Database.Connection.ConnectionString = $@"data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path};Integrated Security=True;Connect Timeout=30";
            Database.SetInitializer<EducationContext>(new EducationDbInitializer());

        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StudentPoll> StudentPolls { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Classes> Classes { get; set; }
    }
}
