using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WS.HTZF.Application.Resources;
using WS.HTZF.Application.Services;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Core.HttpController;
using WS.HTZF.Utilities.Extensions;

namespace HTZF.Manage.Api.Controllers
{
    /// <summary>
    /// 文件上传接口
    /// </summary>
    [RoutePrefix("api/fileupload")]
    public class FileController : ApiController
    {
        private readonly FileService fileService;

        public FileController(FileService  fileService)
        {
            this.fileService = fileService;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[Route("file")]
        //public async Task<ApiResult<FileUploadResult>> UploadFile(HttpPostedFileBase file)
        //=> await ApiResult(file, "file");


        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("image")]
        public async Task<ApiResult<FileUploadResult>> UploadImage()
        {
            var fileType= HttpContext.Current.Request.Form["fileType"];
            HttpPostedFile file = HttpContext.Current.Request.Files["fileUp"];
            return await ApiResult(file, fileType);
        }
     
        /// <summary>
        /// 包上传
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[Route("package")]
        //public async Task<ApiResult<FileUploadResult>> UploadPackage(HttpPostedFileBase file)
        //     => await ApiResult(file, "images");

        private async Task<ApiResult<FileUploadResult>> ApiResult(HttpPostedFile file, string fileType)
        {
            if (file == null || file.ContentLength < 0) throw new ParameterNullException($"{nameof(file)}参数为空.");

            var fileName = file.FileName;
            using (var stream = file.InputStream)
            {
                var fBytes = stream.ReadAllBytes();
                var result = await UploadFileAsync(fileType, fileName, fBytes);
                return new ApiResult<FileUploadResult>() { Result = result };
            }
        }

        private async Task<FileUploadResult> UploadFileAsync(string fileType, string fileName, byte[] fBytes)
        {
            var fileExt = Path.GetExtension(fileName);
            var currUrl = HttpContext.Current.Request.Url.Authority;
            var result = await fileService.UploadFileAsync(currUrl, fileType, fileExt, fBytes);
            return result;
        }
    }
   
}
