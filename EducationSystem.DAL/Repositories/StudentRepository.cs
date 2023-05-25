using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Repositories
{
    public class StudentRepository
    {
        private readonly EducationContext _educationContext;
        public StudentRepository()
        {
            _educationContext = new EducationContext();
        }

        public List<Student> GetList()
        {
            return _educationContext.Students.Where(x => x.IsActive == true).ToList();
        }

        public List<Student> GetListBySearh(string searchText, int classesId)
        {
            if (searchText == "")
            {
                return _educationContext.Students.Where(x => x.ClassesID == classesId && x.IsActive == true).ToList();
            }
            else
            {
                return _educationContext.Students.Where(x => x.ClassesID == classesId && (x.FirstName.Contains(searchText) || x.LastName.Contains(searchText)) && x.IsActive == true).ToList();
            }
        }

        public List<Student> GetListByClassesId(int id)
        {
            return _educationContext.Students.Where(x => x.IsActive == true && x.ClassesID == id).ToList();
        }

        public Student GetById(int id)
        {
            return _educationContext.Students.Where(x => x.IsActive == true && x.StudentID == id).FirstOrDefault();
        }

        public void AddStudent(Student student)
        {
            _educationContext.Students.Add(student);
            _educationContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {

            _educationContext.Students.Attach(student);
            _educationContext.Entry(student).State = EntityState.Modified;
            _educationContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _educationContext.Students.Attach(student);
            student.IsActive = false;
            _educationContext.SaveChanges();
        }
    }
}
