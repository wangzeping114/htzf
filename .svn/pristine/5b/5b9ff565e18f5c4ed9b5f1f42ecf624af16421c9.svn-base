using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;
using WS.HTZF.Application.Services;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.MvcApp.Filter;
using WS.HTZF.Utilities.Helper;

namespace WS.HTZF.MvcApp.Controllers
{

    public class AdminController : BaseController
    {
        public PassportService PassportService { get; }

        public AdminController(PassportService passportService)
        {
            PassportService = passportService;
        }
        public ActionResult Login() 
        {
            return View();
        }
        [Authorize]
        [OutputCache]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
 
        public string extest() 
        {
            throw new NotFoundException("fjijf");
        }
        [HttpGet]
        public ActionResult GetVerifyCode()
        {
            var verify = VerifyCodeHelper.CreateVerifyCode();
            var stream = new MemoryStream();
            verify.Bitmap.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), @"image/png");//返回FileContentResult图片
        }
    }
}