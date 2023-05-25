using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Migrations
{
    public class EducationDbInitializer : CreateDatabaseIfNotExists<EducationContext>
    {
        protected override void Seed(EducationContext context)
        {

            context.UserRoles.Add(new UserRole() { 
                 UserRoleName = "Yönetici",
                 CreatedDate = DateTime.Now,
                 IsActive = true,
            });

            context.UserRoles.Add(new UserRole()
            {
                UserRoleName = "Koordinatör",
                CreatedDate = DateTime.Now,
                IsActive = true,
            });

            context.UserRoles.Add(new UserRole()
            {
                UserRoleName = "Eğitmen",
                CreatedDate = DateTime.Now,
                IsActive = true,
            });

            context.SaveChanges();


            context.Branches.Add(new Branch() { 
                BranchName = "Bakırköy",
                IsActive = true,
                CreatedDate = DateTime.Now,
                BMail = "bakirkoy@badam.com",
                BAdress = "İncirli",
                BPhone ="123456789",          
            });
            context.SaveChanges();

            context.Users.Add(new User() { 
                FirstName ="Admin",
                LastName = "Admin",
                BirthDate = new DateTime(1997,01,01),
                IsActive = true,
                CreatedDate = DateTime.Now,
                Email = "admin@admin.com",
                Password = "123456",
                Phone ="123456789",
                BranchID = 1,
                UserRoleID = 1
                
            });
            context.SaveChanges();
            base.Seed(context);
           
        }
    }
}
