using Album.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Configurations
{
    public class FileConfigurations: IEntityTypeConfiguration<UserFile>
    {
        public void Configure(EntityTypeBuilder<UserFile> builder)
        {
            builder.HasKey(t => new { t.ID });
            builder.HasOne(t => t.Deadline).WithMany(ur => ur.UserFile)
                .HasForeignKey(pc => pc.file_DeadlineId);
        }
    }
}
