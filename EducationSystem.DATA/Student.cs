using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DATA
{
    public class Student
    {

        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }      
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string ImagePath { get; set; }
        public int ClassesID { get; set; }

        public virtual Classes Classes { get; set; }
       
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            } 
        }
    }
}
