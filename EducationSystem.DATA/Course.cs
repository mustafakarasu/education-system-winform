using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DATA
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual List<Classes> Classes { get; set; }
        public virtual List<Branch> Branches { get; set; }
        public Course()
        {
            Classes = new List<Classes>();
            Branches = new List<Branch>();
        }

        public string FullCourseName
        {
            get
            {
                return CourseName + " " + CourseTime + " saat";
            }
        }
    }
}
