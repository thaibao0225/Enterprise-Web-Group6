using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    public class RegisterCourse
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
