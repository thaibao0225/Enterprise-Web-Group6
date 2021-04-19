﻿using System;
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
{//Admin,A Marketing Management,A Marketing Coordinator,Student
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

        [EmailAddress]
        string Email { get; set; }

        [BindProperty]
        public string mess { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deadline = await _context.Deadline.FirstOrDefaultAsync(m => m.dl_Id == id);

            //// Hien thi file
            var userFile = _context.userFiles.Where(a => a.file_DeadlineId == id);

            userFilesList = userFile.ToList();

            /// Hien thi Comment
            /// var article = from a in _context.Article select a; 


            var userComment = _context.Comments.Where(a => a.commentDeadline == id);

            userCommentList = userComment.ToList();

            mess = "";

            if (Deadline == null)
            {
                return NotFound();
            }
            return Page();
        }



        [Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        [Display(Name = "Chọn file upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }


        



        public async Task<IActionResult> OnPostAsync(int id)
        {
            var queryEmail = from aDL in _context.Deadline 
                             join aEV in _context.Article on aDL.ArticleId equals aEV.ID
                             join aC in _context.Courses on aEV.courseId equals aC.course_Id 
                             join aRC in _context.RegisterCourse on aC.course_Id equals aRC.CourseId 
                             join aU in _context.Users on aRC.UserId equals aU.Id
                             select new { aDL, aEV, aC, aRC, aU };
            

            foreach (var item in queryEmail)
            {
                Email = item.aU.Email;
            }

            if (agreeSubmit)
            {
                

                if (FileUploads != null) 
                {
                    string supportedTypes = ".pdf";
                    
                    foreach (var FileUpload in FileUploads)
                    {
                        
                        string[] arrListStr = FileUpload.FileName.Split('.');
                        if (supportedTypes.Contains(arrListStr[1]))
                        {
                            string mess = "You was submited" + FileUpload.FileName;

                            await _emailSender.SendEmailAsync("thaibao0225@gmail.com", mess, "Submited");

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

                            mess = "";
                        }
                        else
                        {
                            mess = "Only .pdf";
                        }
                        
                    }


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




            var userFile = _context.userFiles.Where(a => a.file_DeadlineId == id);

            userFilesList = userFile.ToList();

            var userComment = _context.Comments.Where(a => a.commentDeadline == id);

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
