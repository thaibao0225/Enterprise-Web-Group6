using Album.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FGW_Enterprise_Web.Data.Configurations
{
    class RegisterEventCourseConfigurations : IEntityTypeConfiguration<RegisterEventCourse>
    {
        public void Configure(EntityTypeBuilder<RegisterEventCourse> builder)
        {
            builder.HasKey(t => new { t.re_CourseId, t.re_Event });

            builder.HasOne(t => t.Article).WithMany(ur => ur.RegisterEventCourse)
                .HasForeignKey(pc => pc.re_Event);

            builder.HasOne(t => t.Course).WithMany(ur => ur.RegisterEventCourse)
                .HasForeignKey(pc => pc.re_CourseId);


        }
    }
}
