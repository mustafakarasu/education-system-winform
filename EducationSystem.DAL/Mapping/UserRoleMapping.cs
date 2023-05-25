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
    public class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapping()
        {
            HasKey(x => x.UserRoleID);
            Property(x => x.UserRoleID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(x => x.Users).WithRequired(x => x.UserRole).HasForeignKey(x => x.UserRoleID);
        }
    }
}
