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
        public int rescmt_CmtId { set; get; }
        public  Comment Comment { set; get; }
        public int rescmt_FileId { set; get; }
        public  UserFile UserFile { set; get; }

    }
}
