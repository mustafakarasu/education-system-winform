using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DATA
{
    public class StudentPoll
    {
        public int PollID { get; set; }
        public DateTime PollDate { get; set; }
        public bool IsHere { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Classes Classes { get; set; }
    }
}
