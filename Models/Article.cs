using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ngày đăng")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { set; get; }
    }
}
