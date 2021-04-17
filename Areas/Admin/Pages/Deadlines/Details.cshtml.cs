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

namespace Album.Areas.Admin.Pages.Deadlines
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        private IHostingEnvironment _environment;

        public DetailsModel(AppDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public Deadline Deadline { get; set; }

        public UserFile UserFile { get; set; }

        public List<UserFile> userFilesList { get; set; }

        public List<Comment> userCommentList { get; set; }

        [BindProperty]
        public Comment cuurentComment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deadline = await _context.Deadline.FirstOrDefaultAsync(m => m.dl_Id == id);

            //// Hien thi file
            var userFile = _context.userFiles;

            userFilesList = userFile.ToList();

            ///// Hien thi Comment

            //var userComment = _context.Comment;

            //userCommentList = userComment.ToList();


            if (Deadline == null)
            {
                return NotFound();
            }
            return Page();
        }



        [Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Chọn file upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }






        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (FileUploads != null)
            {
                foreach (var FileUpload in FileUploads)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "uploads", FileUpload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await FileUpload.CopyToAsync(fileStream);
                    }

                    UserFile = new UserFile()
                    {
                        Title = FileUpload.FileName,
                        file_IsSelected = false,
                        file_DeadlineId = id,
                        file_CreateBy = "Thai Bao"
                    };
                }

                _context.userFiles.Add(UserFile);
                await _context.SaveChangesAsync();
            }

            //if(cuurentComment != null)
            //{
            //    cuurentComment.comment_DateUpload = DateTime.Now;

            //    _context.Comment.Add(cuurentComment);
            //    await _context.SaveChangesAsync();
            //}



            var userFile = _context.userFiles;

            userFilesList = userFile.ToList();

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
