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
    public class StudentPollMapping : EntityTypeConfiguration<StudentPoll>
    {
        public StudentPollMapping()
        {
            HasKey(x => x.PollID);
            Property(x => x.PollID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PollDate).IsRequired();
        }
    }
}
