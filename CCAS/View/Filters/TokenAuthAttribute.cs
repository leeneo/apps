using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace CCAS.Filters
{
    //ActionFilter
    public class TokenAuthAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await Run();
        }

        static async Task Run()
        {
            //Thread.Sleep(700);
            //Console.WriteLine("���Ǻ�̨�̵߳���");
            await Task.Delay(2000);
        }
    }
}