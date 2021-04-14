using Album.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FGW_Enterprise_Web.Data.Configurations
{
    class RegisterDeadlineConfigurations : IEntityTypeConfiguration<RegisterDeadline>
    {
        public void Configure(EntityTypeBuilder<RegisterDeadline> builder)
        {
            builder.HasKey(t => new { t.rd_EventId, t.rd_DeadlineId });
            builder.HasOne(t => t.Article).WithMany(ur => ur.RegisterDeadline)
                .HasForeignKey(pc => pc.rd_EventId);
            builder.HasOne(t => t.Dealine).WithMany(ur => ur.RegisterDeadline)
                .HasForeignKey(pc => pc.rd_DeadlineId);
        }
    }
}
