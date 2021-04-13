using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Models
{
    [Table("DeadlineCate")]
    public class DeadlineCate
    {
        [Key]
        public int dlCate_Id { get; set; }

        public string dlCate_Name { get; set; }

        public string dlCate_Description { get; set; }
    }
}
