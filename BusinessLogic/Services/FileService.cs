using BusinessLogic.Intefaces;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {

        public void DeleteProductImage(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }else
            {
               return;
            }
        }

        public string SaveProductImage(IFormFile file)
        {
            // get image destination path
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            string name = Guid.NewGuid().ToString();    // random name
            string extension = Path.GetExtension(file.FileName); // get original extension
            string fullName = name + extension;         // full name: name.ext

            // create destination image file path
            string imagePath = Path.Combine(folderName, fullName);
            string imageFullPath = Path.Combine(pathToSave, fullName);

            // save image on the folder
            using (FileStream fs = new FileStream(imageFullPath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            // return image file path
            return imagePath;
        }
    }
}