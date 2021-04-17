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
        public UserFile userFileList { get; set; }

        [BindProperty]
        public List<FileManagement> FileManagementList { get; set; }

        [BindProperty]
        public bool checkboxaa { get; set; }

        public IndexModel (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet()
        {
            var userFileQuery = from a in _context.userFiles select a;

            var query = from a in _context.Article
                        join b in _context.Deadline on a.ID equals b.ArticleId
                        join cc in _context.userFiles on b.dl_Id equals cc.file_DeadlineId
                        select new { a, b, cc };

            var data = await query
               .Select(x => new FileManagement()
               {
                   NameEvent= x.a.Title,
                   NameFile = x.cc.Title,
                   NameDeadline = x.b.Title,
                   FileSelect = x.cc.file_IsSelected,
                   DeadId = x.b.dl_Id
               }).ToListAsync();
            FileManagementList = data.ToList();

            checkboxaa = false;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {


            foreach (var item in FileManagementList)
            {
                UserFile userFile = _context.userFiles.Single(a => a.file_DeadlineId == item.DeadId && a.Title == item.NameFile);
                //Field which will be update  
                userFile.file_IsSelected = item.FileSelect;
                // executes the appropriate commands to implement the changes to the database  

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            };

            bool haha = checkboxaa;

            if (haha)
            {

            }

            // Print
            var userFileQuery = from a in _context.userFiles select a;

            var query = from a in _context.Article
                        join b in _context.Deadline on a.ID equals b.ArticleId
                        join cc in _context.userFiles on b.dl_Id equals cc.file_DeadlineId
                        select new { a, b, cc };

            var data = await query
               .Select(x => new FileManagement()
               {
                   NameEvent = x.a.Title,
                   NameFile = x.cc.Title,
                   NameDeadline = x.b.Title,
                   FileSelect = x.cc.file_IsSelected,
                   DeadId = x.b.dl_Id
               }).ToListAsync();
            FileManagementList = data.ToList();

            return Page();
            // Print 
        }
    }
}
