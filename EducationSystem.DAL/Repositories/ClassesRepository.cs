using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Repositories
{
    public class ClassesRepository
    {
        private readonly EducationContext _educationContext;
        public ClassesRepository()
        {
            _educationContext = new EducationContext();
        }

        public List<Classes> GetList()
        {
            return _educationContext.Classes.Where(x => x.IsActive == true).ToList();
        }

        public List<Classes> GetListByUserRoleId(int id)
        {
            return _educationContext.Classes.Where(x => x.ClassesID == id).ToList();
        }

        public List<Classes> GetListByBranchId(int id)
        {
            return _educationContext.Classes.Where(x => x.BranchID == id && x.IsActive == true).ToList();
        }


        public List<Classes> GetListByInstructorId(int id)
        {
            return _educationContext.Classes.Where(x => x.IsActive == true && x.InstructorID == id).ToList();
        }

        public Classes GetById(int id)
        {
            return _educationContext.Classes.Where(x => x.IsActive == true && x.ClassesID == id).FirstOrDefault();
        }

        public void AddClasses(Classes classes)
        {
            _educationContext.Classes.Add(classes);
            _educationContext.SaveChanges();
        }

        public void UpdateClasses(Classes classes)
        {

            _educationContext.Classes.Attach(classes);
            _educationContext.Entry(classes).State = EntityState.Modified;
            _educationContext.SaveChanges();
        }

        public void DeleteClasses(Classes classes)
        {
            _educationContext.Classes.Attach(classes);
            classes.IsActive = false;
            _educationContext.SaveChanges();
        }
    }
}
