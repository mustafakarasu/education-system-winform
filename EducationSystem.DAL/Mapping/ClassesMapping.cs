using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Mapping
{
    public class ClassesMapping : EntityTypeConfiguration<Classes>
    {
        public ClassesMapping()
        {
            HasKey(x => x.ClassesID);
            Property(x => x.ClassesID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ClassesCode).HasMaxLength(10).IsRequired();
            Property(x => x.StartCourseDate).IsRequired();
            Property(x => x.EndCourseData).IsRequired();
            Property(x => x.LessonDailyTime).IsRequired();
            Property(x => x.WeekDays).IsRequired();

            HasRequired(x => x.Course).WithMany(x => x.Classes).HasForeignKey(x => x.CourseID);
            HasRequired(x => x.Instructor).WithMany(x => x.Classes).HasForeignKey(x => x.InstructorID).WillCascadeOnDelete(false);

        }
    }
}
