using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Album.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Album.Areas.Admin.Pages.CourseManagement
{
    public class AddUserModel : PageModel
    {

        private readonly AppDbContext _context;

        public AddUserModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
    }
}
