using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("RegisterEvents")]
    public class RegisterEvent
    {
        public int resEvent_CourseId { set; get; }               
        public Course Course { set; get; }
        public int resEvent_EventId { set; get; }
        public Article Article { set; get; }

    }
}
