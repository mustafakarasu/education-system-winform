using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Repositories
{
    public class BranchRepository
    {
        private readonly EducationContext _educationContext;
        public BranchRepository()
        {
            _educationContext = new EducationContext();
        }

        public List<Branch> GetList()
        {
            return _educationContext.Branches.Where(x => x.IsActive == true).ToList();
        }

        public Branch GetById(int id)
        {
            return _educationContext.Branches.Where(x => x.IsActive == true && x.BranchID == id).FirstOrDefault();
        }

        public List<Branch> GetListById(int id)
        {
            return _educationContext.Branches.Where(x => x.IsActive == true && x.BranchID == id).ToList();
        }

        public void AddBranch(Branch branch)
        {
            _educationContext.Branches.Add(branch);
            _educationContext.SaveChanges();
        }

        public void UpdateBranch(Branch branch)
        {
            _educationContext.Branches.Attach(branch);
            _educationContext.Entry(branch).State = EntityState.Modified;
            _educationContext.SaveChanges();
        }

        public void DeleteBranch(Branch branch)
        {
            _educationContext.Branches.Attach(branch);
            branch.IsActive = false;
            _educationContext.SaveChanges();
        }
    }
}
