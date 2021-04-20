using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Album.Models
{
    public class AppUser : IdentityUser
    {

        [MaxLength(100)]
        public string FullName {set; get;}
        [MaxLength(255)]
        public string Address {set; get;}
        [DataType(DataType.Date)]
        public DateTime? Birthday {set; get;}
        public List<RegisterCourse> RegisterCourse { get; set; }
        public List<RegisterGrade> RegisterGrade { get; set; }





    }
}