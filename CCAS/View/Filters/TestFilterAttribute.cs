using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace CCAS.Filters
{
    public class TestFilterAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.HttpContext.Response.Body.Write(Encoding.GetEncoding("GB2312").GetBytes("Actionִ��֮ǰ" + Message + "<br />"));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.HttpContext.Response.Body.Write(Encoding.GetEncoding("GB2312").GetBytes("Actionִ��֮��" + Message + "<br />"));
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            filterContext.HttpContext.Response.Body.Write(Encoding.GetEncoding("GB2312").GetBytes("����Result֮ǰ" + Message + "<br />"));
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            filterContext.HttpContext.Response.Body.Write(Encoding.GetEncoding("GB2312").GetBytes("����Result֮��" + Message + "<br />"));
        }
    }
}