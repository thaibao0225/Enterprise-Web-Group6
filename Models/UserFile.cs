using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("File")]

    public class UserFile
    {

        public int ID { get; set; }

        [Display(Name = "Tên File")]
        public string Title { get; set; }

        [Display(Name = "Thời hạn")]
        public int file_DeadlineId { get; set; }
        public Deadline Deadline { set; get; }
        public bool file_IsSelected { get; set; }

        [DataType(DataType.Date)]
        public DateTime file_DateUpload { get; set; }

        public string file_CreateBy { get; set; }
        public List<RegisterComment> RegisterComment { get; set; }


    }
}
