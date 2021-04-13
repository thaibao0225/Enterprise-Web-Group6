using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("RegisterDeadlines")]
    public class RegisterDeadline
    {
        [Key]
        public int rd_DeadineCate { get; set; }

        public int rd_DeadlineId { get; set; }

    }
}
