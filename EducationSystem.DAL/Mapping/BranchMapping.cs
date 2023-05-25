using EducationSystem.DATA;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EducationSystem.DAL.Mapping
{
    public class BranchMapping : EntityTypeConfiguration<Branch>
    {
        public BranchMapping()
        {
            HasKey(x => x.BranchID);
            Property(x => x.BranchID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.BMail).HasMaxLength(70).IsRequired();
            Property(x => x.BPhone).HasMaxLength(30).IsRequired();
            Property(x => x.BAdress).HasMaxLength(250);

            HasMany(x => x.Courses).WithMany(x => x.Branches);
        }
    }
}
