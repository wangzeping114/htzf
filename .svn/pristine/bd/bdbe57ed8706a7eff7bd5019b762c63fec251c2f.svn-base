using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WS.HTZF.Core.HttpController;

namespace WS.HTZF.WebApi.Filter
{
    /// <summary>
    /// 全局模型验证
    /// </summary>
    public class ModelStateValidFitter: ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Your Can  Do Something ..
        }
        /// <summary>
        /// 全局Dto模型验证，为了简化代码，不想在每一个控制器里头加上一个ModelState.IsValid方式来验证，所以我把它注册为全局的验证
        /// </summary>
        /// <param name="actionContext">action Context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var apiResult = new ApiResult();
                foreach (var item in actionContext.ModelState.Values)
                {
                    if (item.Errors.Count > 0)
                    {
                        apiResult = ApiResult.GetArgumentError(item.Errors[0].ErrorMessage);
                        break;
                    }
                }
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.OK,
                    apiResult,
                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                );
            }
        }
    }
}