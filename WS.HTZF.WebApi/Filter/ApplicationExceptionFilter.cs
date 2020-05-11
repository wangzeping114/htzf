using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Core.HttpController;
using WS.HTZF.Core.LogHelper;
using WS.HTZF.Utilities.Helper;

namespace WS.HTZF.WebApi.Filter
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class ApplicationExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// 全局异常处理
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {

            ApiResult apiResult;
            var exception = context.Exception;
            if (exception is InvalidArgumentException)
            {
                apiResult = ApiResult.GetArgumentError(exception.Message);
            }
            else if (exception is NotFoundException)
            {
                apiResult = ApiResult.GetNotFound(exception.Message);
            }
            else if(exception is NotImplementException)
            {
                apiResult = ApiResult.GetNotImplement(exception.Message);
            }
            else
            {
                apiResult = ApiResult.GetServerError($"请与管理员联系!{exception.Message}");
                //无法识别的异常则用log4net记录下来
                LazyFactory<Log4Net>.Instance.Error(apiResult.StatusMessage);
            }
            context.Response = context.Request.CreateResponse(
                HttpStatusCode.OK,
                apiResult,
                context.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
        }
    }
}

