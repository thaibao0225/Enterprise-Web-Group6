using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Album.Data;
using Album.Models;

namespace Album.Areas.Admin.Pages.Deadlines
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Deadline Deadline { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deadline = await _context.Deadline.FirstOrDefaultAsync(m => m.dl_Id == id);

            if (Deadline == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
