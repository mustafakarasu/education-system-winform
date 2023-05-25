using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Repositories
{
    public class UserRoleRepository
    {
        private readonly EducationContext _educationContext;
        public UserRoleRepository()
        {
            _educationContext = new EducationContext();
        }

        public List<UserRole> GetList()
        {
            return _educationContext.UserRoles.Where(x => x.IsActive == true).ToList();
        }

        public UserRole GetById(int id)
        {
            return _educationContext.UserRoles.Where(x => x.IsActive == true && x.UserRoleID == id).FirstOrDefault();
        }

        public UserRole GetByRoleName(string roleName)
        {
            return _educationContext.UserRoles.Where(x => x.UserRoleName.ToLower() == roleName.ToLower()).FirstOrDefault();
        }

        public void AddUserRole(UserRole userRole)
        {
            _educationContext.UserRoles.Add(userRole);
            _educationContext.SaveChanges();
        }

        public void UpdateUserRole(UserRole userRole)
        {
            _educationContext.UserRoles.Attach(userRole);
            _educationContext.Entry(userRole).State = EntityState.Modified;
            _educationContext.SaveChanges();
        }

        public void DeleteUserRole(UserRole userRole)
        {
            _educationContext.UserRoles.Attach(userRole);
            userRole.IsActive = false;
            _educationContext.SaveChanges();
        }
    }
}
