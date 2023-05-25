using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Repositories
{
    public class CourseRepository
    {
        private readonly EducationContext _educationContext;
        public CourseRepository()
        {
            _educationContext = new EducationContext();
        }

        public List<Course> GetList()
        {
            return _educationContext.Courses.Where(x => x.IsActive == true).ToList();
        }


        public Course GetById(int id)
        {
            return _educationContext.Courses.Where(x => x.IsActive == true && x.CourseID == id).FirstOrDefault();
        }
        

        public void AddCourse(Course course)
        {
            _educationContext.Courses.Add(course);
            _educationContext.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {

            _educationContext.Courses.Attach(course);
            _educationContext.Entry(course).State = EntityState.Modified;
            _educationContext.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            _educationContext.Courses.Attach(course);
            course.IsActive = false;
            _educationContext.SaveChanges();
        }
    }
}
