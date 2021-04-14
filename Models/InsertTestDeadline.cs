using System;
using Microsoft.Extensions.DependencyInjection;
using Album.Data;
using System.Linq;

namespace Album.Models
{
    public class InsertTestDeadline
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                if (context.Deadline.Any())
                {
                    // Đã có dữ liệu
                    return;
                }

                context.AddRange(new Deadline[] {
                   new Deadline() {
                       Title = "Assingment1",
                       dl_TimeDeadline = DateTime.Parse("4-5-2021"),
                       dl_Description = @"Giới thiệu C#, cài đặt .NET Core SDK, VSC và viết
                                   chương trình CS (C# CSharp) đầu tiên chạy đa nền tảng Windows,
                                   macOS, Linux, hàm Main trong C# và viết các
                                   comment - ghi chú - xml document",
                       dl_CreateBy = "Nhu",
                       dl_Status = "open",
                       dl_ModifiedBy = "Nhu",
                       dl_CreateDate = DateTime.Parse("4-6-2021")},

                  

                });
                context.SaveChanges();
            }
        }

    }
}
