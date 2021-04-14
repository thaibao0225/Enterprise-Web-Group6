using Album.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FGW_Enterprise_Web.Data.Configurations
{
    class RegisterCommentConfigurations : IEntityTypeConfiguration<RegisterComment>
    {
        public void Configure(EntityTypeBuilder<RegisterComment> builder)
        {
            builder.HasKey(t => new { t.DeadlineId, t.rescmt_CmtId});
            builder.HasOne(t => t.Deadline).WithMany(ur => ur.RegisterComment)
                .HasForeignKey(pc => pc.DeadlineId);
            builder.HasOne(t => t.Comment).WithMany(ur => ur.RegisterComment)
                .HasForeignKey(pc => pc.rescmt_CmtId);
        }
    }
}
