using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("Deadlines")]
    public class Deadline
    {
        [Key]
        public int dl_Id { get; set; }

        public string dl_Name { get; set; }


        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Thời hạn")]
        [DataType(DataType.Date)]
        public DateTime dl_TimeDeadline { get; set; }

        [Display(Name = "Nội dung")]
        public string dl_Description { set; get; }

        [Display(Name = "Nộp bởi")]
        public string dl_CreateBy { set; get; }

        public string dl_Status { set; get; }

        public string dl_ModifiedBy { set; get; }
        public string dl_CreateDate { set; get; }

    }
}
