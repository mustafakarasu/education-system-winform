using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DATA
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public int UserRoleID { get; set; }
        public int BranchID { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual List<Classes> Classes { get; set; }

        public User()
        {
            Classes = new List<Classes>();
        }


        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }        
        }


    }
}
