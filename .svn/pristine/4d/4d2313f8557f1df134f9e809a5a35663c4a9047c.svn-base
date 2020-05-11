
using System.Web.Mvc;

namespace WS.HTZF.MvcApp.Filter
{
    /// <summary>
    /// 全局模型验证处理
    /// </summary>
    public class ModelStateValid : ActionFilterAttribute,IExceptionFilter
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
      

            //if (!filterContext.ModelState.IsValid)
            //{
            //    var apiResult = new ApiResult();
            //    foreach (var item in actionContext.ModelState.Values)
            //    {
            //        if (item.Errors.Count > 0)
            //        {
            //            apiResult = ApiResult.GetArgumentError(item.Errors[0].ErrorMessage);
            //            break;
            //        }
            //    }
            //    actionContext.Response = actionContext.Request.CreateResponse(
            //        HttpStatusCode.OK,
            //        apiResult,
            //        actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
            //    );
            //}
        }
        public void OnException(ExceptionContext filterContext)
        {
            throw new System.NotImplementedException();
        }

    
    }
}