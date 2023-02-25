using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class EmploymentConfigurations : IEntityTypeConfiguration<Employment>
    {
        public void Configure(EntityTypeBuilder<Employment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Relatives).WithMany(x => x.Employments).HasForeignKey(x => x.RelativeId);
            builder.HasOne(x => x.Readings).WithMany(x => x.Employments).HasForeignKey(x => x.ReadingId);
            builder.HasOne(x => x.Writings).WithMany(x => x.Employments).HasForeignKey(x => x.WritingId);
            builder.HasOne(x => x.Speakings).WithMany(x => x.Employments).HasForeignKey(x => x.SpeakingId);
        }
    }
}
