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
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
        {
            HasKey(x => x.CourseID);
            Property(x => x.CourseID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CourseName).HasMaxLength(150).IsRequired();
            Ignore(x => x.FullCourseName);
        }
    }
}
