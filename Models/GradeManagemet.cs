using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    public class GradeManagemet
    {
        [Key]
        public int Id { get; set; }
        public int grade { get; set; }
        public int DeadIdG { get; set; }
        public Deadline Deadline { get; set; }
    }
}
