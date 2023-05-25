using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DATA
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CoordinatorID { get; set; }
        public string BMail { get; set; }
        public string BPhone { get; set; }
        public string BAdress { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<Course> Courses { get; set; }

        public Branch()
        {
            Courses = new List<Course>();
            Users = new List<User>();
        }
    }
}
