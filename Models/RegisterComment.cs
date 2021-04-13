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
        public int rescmt_CmtId { get; set; }

        public int rescmt_FileId { get;set }

    }
}
