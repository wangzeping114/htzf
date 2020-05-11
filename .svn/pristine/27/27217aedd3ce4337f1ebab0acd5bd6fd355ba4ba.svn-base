using System.Threading.Tasks;
using System.Web.Http;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Services;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Core.HttpController;


namespace WS.HTZF.WebApi.Controllers
{
    /// <summary>
    /// This is WebApi Test Smpile 
    /// </summary>
    public class DefaultController : ApiController
    {
        private readonly PassportService passportService;

        /// <summary>
        /// ctor.
        /// </summary>
        public DefaultController(PassportService passportService)
        {
            this.passportService = passportService;
        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("gettest")]
        public async Task<ApiResult> GetTest()
        {
            await Task.CompletedTask;
            return ApiResult.Success;
        }


        [HttpGet]
        [Route("exptiontest")]
        public async Task<ApiResult> GetTest2()
        {
            await Task.CompletedTask;
            throw new NotImplementException(nameof(GetTest2));
            return ApiResult.Success;
        }


        /// <summary>
        /// 注册测试.
        /// </summary>
        /// <param name="newAccountDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<ApiResult> Register(NewAccountDto newAccountDto)
        {
            await passportService.RegisterAppUserAsync(newAccountDto);
            return ApiResult.Success;
        }
    }
}
