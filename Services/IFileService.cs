using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Services
{
   public interface IFileService
    {
        void UploadFile(List<IFormFile> files, string subDirectory);
        void DownloadFilesAsync(string subDirectory);
         //string SizeConverter(long bytes);
    }
}
