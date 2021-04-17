using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Album.Data;
using Album.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Album.Areas.Admin.Pages.fileManagement
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public List<UserFile> userFileList { get; set; }

        public IndexModel (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet()
        {
            var userFileQuery = from a in _context.userFiles select a;

            userFileList = userFileQuery.ToList();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync() 
        {


            return Page();
        }
    }
}
