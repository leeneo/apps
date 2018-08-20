using System;
using System.Web;
using System.Collections.Generic;
using Newtonsoft.Json;//不要管红线提示，程序可以正常运行

namespace CSharp {
    class TestResponse {
        
        public static void Run () {
            try
            {
                //System.Web.HttpContext.Current.Response.Write("Response");
                //Console.WriteLine("LcswResultNotity", "Write:Response");
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                //Console.WriteLine("LcswResultNotity", "Write:CompleteRequest");
                //HttpContext.Current.Response.End();
                Console.WriteLine("LcswResultNotity", "Write:End");
            }
            catch (Exception e)
            {
                Console.WriteLine("LcswResultNotity", e.ToString());
            }
            finally
            {
                Console.WriteLine("LcswResultNotity", "Write");
                Console.WriteLine("LcswResultNotity", "write:finally");
            }
        }
    }
}