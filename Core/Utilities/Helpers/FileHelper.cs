using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\Uploads";
        private static string _folderName = "";

        public static IDataResult<string> Add(IFormFile file, string fileName)
        {
            _folderName = "\\" + fileName + "\\";
            var fileExists = CheckFileExists(file);
            if (!fileExists.Success)
            {
                return new ErrorDataResult<string>(fileExists.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessDataResult<string>(("Uploads" + _folderName + randomName + type).Replace("\\", "/"), "");
        }
        public static IDataResult<string> Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (!fileExists.Success)
            {
                return new ErrorDataResult<string>(null, fileExists.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();
            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessDataResult<string>((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }
        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }
    }
}
