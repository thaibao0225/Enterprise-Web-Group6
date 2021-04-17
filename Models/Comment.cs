using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int cmt_Id { get; set; }

        public string comment_Content { get; set; }
        public DateTime comment_DateUpload { get; set; }

        public int commentDeadline { get; set; }
        public Deadline Deadline { get; set; }
        //public List<RegisterComment> RegisterComment { get; set; }

    }
}
