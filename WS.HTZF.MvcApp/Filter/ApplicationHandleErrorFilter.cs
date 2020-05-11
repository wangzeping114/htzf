using System.Web.Mvc;

namespace WS.HTZF.MvcApp.Filter
{
  
    public class ApplicationHandleErrorFilter : ActionFilterAttribute,IExceptionFilter
    { 
        public  void OnException(ExceptionContext context)
        {
            context.Result = new ViewResult()
            {
                ViewName = "Error"
            };
            context.ExceptionHandled = true;
        }
 
    }
}