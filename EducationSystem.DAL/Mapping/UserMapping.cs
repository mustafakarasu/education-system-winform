using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.DAL.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(x => x.UserID);
            Property(x => x.UserID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName).HasMaxLength(40).IsRequired();
            Property(x => x.LastName).HasMaxLength(40).IsRequired();
            Property(x => x.Phone).HasMaxLength(20);
            Property(x => x.Email).HasMaxLength(60);     
            Ignore(x => x.FullName);

            HasRequired(x => x.UserRole).WithMany(x => x.Users).HasForeignKey(x => x.UserRoleID);
            HasRequired(x => x.Branch).WithMany(x => x.Users).HasForeignKey(x => x.BranchID);
        }
    }
}
