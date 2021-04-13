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

        public int resEvent_CourseId { get; set; }

        public int resEvent_UserId { get; set; }

        public int resEvent_DeadlineCate { get; set; }

        public int resEvent_EventId { get; set; }

    }
}
