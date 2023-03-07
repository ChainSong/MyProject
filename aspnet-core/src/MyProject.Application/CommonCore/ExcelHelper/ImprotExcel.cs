using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.CommonCore.ExcelHelper
{
    /// <summary>
    /// 将导入的Excel 写入到磁盘
    /// </summary>
    public static class ImprotExcel
    {
        private const string FileDir = "/File/ExcelTemp";
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="avatar"></param>
        /// <param name="reDir"></param>
        /// <returns></returns>
        public async static Task<string> WriteFile(IFormFile avatar, string reDir = FileDir)
        {
            string reName = Guid.NewGuid() + Path.GetExtension(avatar.FileName);
            string dir = GetDirPath(reDir);
            string path = $"{dir}\\{reName}";
            Stream stream = avatar.OpenReadStream();
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await avatar.CopyToAsync(fileStream);
            }
            return $"{reDir}/{reName}";
        }
        public static string GetDirPath(string reDir)
        {
            string dir = $"{Environment.CurrentDirectory}/{reDir}";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return Path.GetFullPath(dir);
        }
    }
}
