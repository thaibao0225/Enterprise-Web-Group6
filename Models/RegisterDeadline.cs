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
        //public int rd_DeadineCate { get; set; } //dl_Id Deadline
        public int rd_DeadineCate { set; get; }
        [ForeignKey("rd_DeadineCate")]
        public virtual Deadline Deadline { set; get; }

        //public int rd_DeadlineId { get; set; } //dlCate_Id DeadlineCate
        public int rd_DeadlineId { set; get; }
        [ForeignKey("rd_DeadlineId")]
        public virtual DeadlineCate DeadlineCate { set; get; }

    }
}
