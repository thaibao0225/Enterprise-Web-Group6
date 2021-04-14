using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("RegisterComments")]
    public class RegisterComment
    {
        [Key]
        //public int rescmt_CmtId { get; set; } //comment_Id Comment
        public int rescmt_CmtId { set; get; }
        [ForeignKey("rescmt_CmtId")]
        public virtual Comment Comment { set; get; }

        //public int rescmt_FileId { get; set; } //ID File
        public int rescmt_FileId { set; get; }
        [ForeignKey("rescmt_FileId")]
        public virtual File File { set; get; }

    }
}
