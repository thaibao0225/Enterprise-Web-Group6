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
        [Key]

        //public int resEvent_CourseId { get; set; } //course_Id Course

        public int resEvent_CourseId { set; get; }               
        [ForeignKey("resEvent_CourseId")]
        public virtual Course Course { set; get; }

        //public int resEvent_UserId { get; set; } //Id Users

        //public int resEvent_UserId { set; get; }
        [ForeignKey("resEvent_UserId")]
        public virtual AppUser AppUser { set; get; }

        //public int resEvent_DeadlineCate { get; set; } // dlCate_Id DeadlineCate

        public int resEvent_DeadlineCate { set; get; }
        [ForeignKey("resEvent_DeadlineCate")]
        public virtual DeadlineCate DeadlineCate { set; get; }

        //public int resEvent_EventId { get; set; } //ID Article

        public int resEvent_EventId { set; get; }
        [ForeignKey("resEvent_EventId")]
        public virtual Article Article { set; get; }

    }
}
