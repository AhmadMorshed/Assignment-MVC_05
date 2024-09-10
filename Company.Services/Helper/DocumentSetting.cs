using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public  class DocumentSetting
    {
        public static string UploadFile(IFormFile file, string folderName)
        {  //1-Get folder path
           // var folderpath = @"C:\\Users\\Ahmad Nakawa\\Desktop\\C# Basic\\Company.Web\\Company.Web\\wwwroot\\Files\\Images\\";
           
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            //2- get file name
            var fileName=$"{Guid.NewGuid()}-{file.FileName}";
            //3-Combine FolderPath  + FilePath
            var filePath = Path.Combine(folderpath, fileName);
            //4-Save File
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return filePath;
        }

    }
}
