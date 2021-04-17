using Album.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Configurations
{
    public class RegisterCourseConfigurations : IEntityTypeConfiguration<RegisterCourse>
    {
        public void Configure(EntityTypeBuilder<RegisterCourse> builder)
        {
            builder.HasKey(t => new { t.UserId, t.CourseId });
            builder.HasOne(t => t.AppUser).WithMany(ur => ur.RegisterCourse)
                .HasForeignKey(pc => pc.UserId);
            builder.HasOne(t => t.Course).WithMany(ur => ur.RegisterCourse)
                .HasForeignKey(pc => pc.CourseId);
        }
    }
}
