using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DATA
{
    public class Classes
    {
        public int ClassesID { get; set; }
        public string ClassesCode { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public DateTime StartCourseDate { get; set; }
        public DateTime EndCourseData { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Lesson { get; set; }
        public int WeekDays { get; set; }
        public int LessonDailyTime { get; set; }
        public int BranchID { get; set; }

        public virtual User Instructor { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual Course Course { get; set; }
        public virtual Branch Branch { get; set; }

        public Classes()
        {
            Students = new List<Student>();
        }
    }
}
