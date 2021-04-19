using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Album.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Album.Areas.Admin.Pages.fileManagement
{
    public class DownFileModel : PageModel
    {
        private IHostingEnvironment _environment;

        private AppDbContext _context;

        public DownFileModel(IHostingEnvironment environment, AppDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            
            Response.ContentType = "application/octet-stream";
            Response.Headers.Add("Content-Disposition", "attachment; filename=\"Bo555s.zip\"");
            string NameFile = "wwwroot\\uploads";

            var query = _context.userFiles.Where(a => a.file_IsSelected == true);


            var files = Directory.GetFiles(Path.Combine(_environment.ContentRootPath, NameFile)).ToList();

            using (ZipArchive archive = new ZipArchive(Response.BodyWriter.AsStream(), ZipArchiveMode.Create))
            {
                foreach (var botFilePath in files)
                {
                    foreach (var item in query)
                    {
                        var botFileName = Path.GetFileName(botFilePath);
                        if (item.Title.Contains(botFileName))
                        {

                            var entry = archive.CreateEntry(botFileName);
                            using (var entryStream = entry.Open())
                            using (var fileStream = System.IO.File.OpenRead(botFilePath))
                            {
                                await fileStream.CopyToAsync(entryStream);
                            }
                        }
                    }
                    
                }
            }
        }
    }
}
