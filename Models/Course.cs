using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int course_Id { get; set; }

        public string course_Name { get; set; }

        public string course_Descrition { get; set; }
        public List<RegisterEvent> RegisterEvent { get; set; }

    }
}
