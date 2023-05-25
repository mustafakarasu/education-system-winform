using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DATA
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public string UserRoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual List<User> Users { get; set; }

        public UserRole()
        {
            Users = new List<User>();
        }
    }
}
