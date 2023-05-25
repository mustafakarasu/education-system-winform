using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Repositories
{
    public class UserRepository
    {
        private readonly EducationContext _educationContext;

        public UserRepository()
        {
            _educationContext = new EducationContext();
        }

        public List<User> GetList()
        {
            return _educationContext.Users.Where(x => x.IsActive == true).ToList();
        }

        public List<User> GetListBySearh(string searchText, int userRoleId)
        {
            if (searchText == "")
            {
                return _educationContext.Users.Where(x => x.UserRole.UserRoleID == userRoleId && x.IsActive == true).ToList();
            }
            else
            {
                return _educationContext.Users.Where(x => x.UserRole.UserRoleID == userRoleId && (x.FirstName.Contains(searchText) || x.LastName.Contains(searchText)) && x.IsActive == true).ToList();
            }            
        }

        public List<User> GetListByBranchId(int id)
        {
            return _educationContext.Users.Where(x => x.IsActive == true && x.BranchID == id).ToList();
        }

        public List<User> GetListByUserRoleId(int id)
        {
            return _educationContext.Users.Where(x => x.UserRoleID == id).ToList();
        }

        public User GetById(int id)
        {
            return _educationContext.Users.Where(x => x.IsActive == true && x.UserID == id).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _educationContext.Users.Add(user);
            _educationContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {

            _educationContext.Users.Attach(user);
            _educationContext.Entry(user).State = EntityState.Modified;
            _educationContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _educationContext.Users.Attach(user);
            user.IsActive = false;
            _educationContext.SaveChanges();
        }
    }
}
