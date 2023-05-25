using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Repositories
{
    public class StudentPollRepository
    {
        private readonly EducationContext _educationContext;
        public StudentPollRepository()
        {
            _educationContext = new EducationContext();
        }

        public List<StudentPoll> GetList()
        {
            return _educationContext.StudentPolls.Where(x => x.IsActive == true).ToList();
        }

        public StudentPoll GetById(int id)
        {
            return _educationContext.StudentPolls.Where(x => x.IsActive == true && x.PollID == id).FirstOrDefault();
        }

        public List<StudentPoll> GetByClassesIdAndPollDate(int classeId, DateTime pollDate)
        {
            return _educationContext.StudentPolls.Where(x => x.IsActive == true && x.ClassID == classeId && x.PollDate == pollDate.Date).ToList();
        }

        public List<StudentPoll> GetListByClassesIdAndStudentId(int classesId, int studentId)
        {
            return _educationContext.StudentPolls.Where(x => x.StudentID == studentId && x.ClassID == classesId).ToList();
        }

        public List<StudentPoll> GetListByClassesId(int classesId)
        {
            return _educationContext.StudentPolls.Where(x => x.ClassID == classesId).ToList();
        }

        public void AddStudentPoll(StudentPoll studentPoll)
        {
            _educationContext.StudentPolls.Add(studentPoll);
            _educationContext.SaveChanges();
        }

        public void UpdateStudentPoll(StudentPoll studentPoll)
        {
            _educationContext.StudentPolls.Attach(studentPoll);
            _educationContext.Entry(studentPoll).State = EntityState.Modified;
            _educationContext.SaveChanges();
        }

        public void DeleteStudentPoll(StudentPoll studentPoll)
        {
            _educationContext.StudentPolls.Attach(studentPoll);
            studentPoll.IsActive = false;
            _educationContext.SaveChanges();
        }
    }
}
