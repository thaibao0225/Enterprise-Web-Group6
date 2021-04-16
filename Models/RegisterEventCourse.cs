using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("RegisterEventCourse")]
    public class RegisterEventCourse 
    {
        public int re_CourseId { get; set; }
        public Course Course { get; set; }


        public int re_Event { get; set; }
        public Article Article { get; set; }
    }
}
