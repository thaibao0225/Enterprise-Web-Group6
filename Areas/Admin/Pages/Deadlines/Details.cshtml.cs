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
using Album.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Album.Areas.Admin.Pages.Deadlines
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;
        private IHostingEnvironment _environment;

        public DetailsModel(AppDbContext context, IHostingEnvironment environment, IEmailSender emailSender)
        {
            _context = context;
            _environment = environment;
            _emailSender = emailSender;
        }

        public Deadline Deadline { get; set; }

        public UserFile UserFile { get; set; }

        public List<UserFile> userFilesList { get; set; }

        [BindProperty]
        public List<Comment> userCommentList { get; set; }

        [BindProperty]
        public Comment cuurentComment { get; set; }

        [BindProperty]
        public string cmtContext { get; set; }

        [BindProperty]
        public bool agreeSubmit { get; set; }

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

            /// Hien thi Comment
            /// var article = from a in _context.Article select a; 


            var userComment = from a in _context.Comments select a;

            userCommentList = userComment.ToList();


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
            if (agreeSubmit)
            {
                await _emailSender.SendEmailAsync("MAIL@gmail.com", "You was submited", "Submited");
            }
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
                    _context.userFiles.Add(UserFile);
                    await _context.SaveChangesAsync();
                }

                
            }


            // phan comment
            if (cmtContext != null)
            {
                cuurentComment = new Comment()
                {
                    commentDeadline = id,
                    comment_DateUpload = DateTime.Now,
                    comment_Content = cmtContext
                };
                                

                _context.Comments.Add(cuurentComment);
                await _context.SaveChangesAsync();
            }


            

            var userFile = _context.userFiles;

            userFilesList = userFile.ToList();

            var userComment = from a in _context.Comments select a;

            userCommentList = userComment.ToList();

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
