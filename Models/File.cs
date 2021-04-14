using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("file")]
    public class File
    {

        [Key]
        public int ID { get; set; }

        [Display(Name = "Tên File")]
        public string Title { get; set; }

        [Display(Name = "Thời hạn")]
        [DataType(DataType.Date)]
        //public DateTime PublishDate { get; set; } //dl_Id File
        //public int rescmt_FileId { set; get; }
        [ForeignKey("PublishDate")]
        public virtual Deadline Deadline { set; get; }

        public bool file_IsSelected { get; set; }

        [DataType(DataType.Date)]
        public DateTime file_DateUpload { get; set; }

        public string file_CreateBy { get; set; }

    }
}
