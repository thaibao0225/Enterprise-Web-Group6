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
        public int dl_Id { get; set; }

        
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }


        [Display(Name = "Thời hạn")]
        [DataType(DataType.Date)]
        public DateTime dl_TimeDeadline { get; set; }


        [Display(Name = "Nội dung")]
        public string dl_Description { set; get; }


        [Display(Name = "Nộp bởi")]
        public string dl_CreateBy { set; get; }


        [Display(Name = "Trạng thái")]
        public string dl_Status { set; get; }


        [Display(Name = "Chỉnh sửa bởi")]
        public string dl_ModifiedBy { set; get; }


        [Display(Name = "Ngày khởi tạo")]
        [DataType(DataType.Date)]
        public DateTime dl_CreateDate { set; get; }
        public List<RegisterDeadline> RegisterDeadline { get; set; }
        public List<UserFile> UserFile { get; set; }



    }
}
