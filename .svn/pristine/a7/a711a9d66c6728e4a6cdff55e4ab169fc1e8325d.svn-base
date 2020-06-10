using System;
using System.IO;
using System.Threading.Tasks;
using WS.HTZF.Application.Resources;
using WS.HTZF.Utilities.Helper;

namespace WS.HTZF.Application.Services
{
    /// <summary>
    /// 文件上传服务
    /// </summary>
    public class FileService
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="url"></param>
       /// <param name="fileType"></param>
       /// <param name="fileExt"></param>
       /// <param name="bytes"></param>
       /// <returns></returns>
        public async Task<FileUploadResult> UploadFileAsync(string url,string fileType, string fileExt, byte[] bytes)
        {

            string tempfile = $"{Guid.NewGuid().ToString()}{fileExt}";

            var fileName = $"Uploads-{fileType}";

            var rootPath = Path.Combine(AppContext.BaseDirectory, fileName);

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            var localPath = Path.Combine(rootPath, tempfile);

            File.WriteAllBytes(localPath, bytes);

        

            //var ossFileName = $"{filePath}/{contentMd5}{fileExt}";
            var fileURL = $"{url}/{fileName}/{tempfile}";
            //File.Delete(localPath);
        

            return new FileUploadResult()
            {
                FileSize = bytes.Length,

                FileURL = fileURL,
            };
        }
    }
}
