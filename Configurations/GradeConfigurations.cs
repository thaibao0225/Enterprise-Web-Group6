using Album.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Configurations
{
    public class GradeConfigurations : IEntityTypeConfiguration<GradeManagemet>
    {
        public void Configure(EntityTypeBuilder<GradeManagemet> builder)
        {
            builder.HasOne(t => t.Deadline).WithMany(ur => ur.gradeManagemets)
                .HasForeignKey(pc => pc.DeadIdG);
        }
    }
}
