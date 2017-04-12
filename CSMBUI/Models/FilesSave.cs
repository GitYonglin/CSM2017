using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CSMBUI.Models
{
    public static class FilesSave
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootPath">根路径</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="File">文件</param>
        /// <returns>返回保存文件名</returns>
        public static async Task<string> FileSave(string rootPath, string savePath, IFormFile File)
        {
            // 获取文件名与扩展名
            var fileName = ContentDispositionHeaderValue
                                .Parse(File.ContentDisposition)
                                .FileName
                                .Trim('"');
            var filePath = $@"{savePath}{fileName}";
            fileName = $@"{rootPath}{filePath}";
            //文件保存
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                await File.CopyToAsync(fs);
                fs.Flush();
            }

            return filePath;
        }
    }

}
