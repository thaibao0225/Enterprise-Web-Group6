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
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        [BindProperty]
        public bool checkboxbb { get; set; }

        [BindProperty]
        public string haha { get; set; }

        public UserFile userFile { get; set; }

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
                   FileId = x.cc.ID,

                   DeadId = x.b.dl_Id
               }).ToListAsync();
            FileManagementList = data.ToList();

            

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {


            if (checkboxaa)
            {

            }


                // Print

   

            var userFileQuery = from aa in _context.userFiles select aa;

            for (int i = 0; i < FileManagementList.Count; i++)
            {
                var fileNameTraVe = FileManagementList[i].FileId;
                var buserFile = userFileQuery.Where(a => a.Title.Contains(FileManagementList[i].FileId.ToString()));

                if (buserFile == null)
                {
                    return BadRequest("false");
                }
                //      userFile = (DbSet<UserFile>)userFile.Where(a => a.Title == "1690-TaThaiBao-GCS18186-Assignmentbrief2.pdf");
                var files = await _context.userFiles.FindAsync(fileNameTraVe);
                files.ID = fileNameTraVe;
                bool aaa = FileManagementList[i].FileSelect;
                files.file_IsSelected = aaa;
                _context.Update(files);
            }
            await _context.SaveChangesAsync();
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
                   FileId = x.cc.ID
               }).ToListAsync();
            FileManagementList = data.ToList();
            return Page();
            // Print 
        }
    }
}
