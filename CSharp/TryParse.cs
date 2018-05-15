using Newtonsoft.Json;
using System;

namespace CSharp
{
    class TryParse
    {

        public static void Run()
        {
            try
            {
                decimal pledge;
                decimal.TryParse("0.01", out pledge);//小于1会转换失败，将目标重置为0
                Console.WriteLine(decimal.TryParse("0.01", out pledge));
                Console.WriteLine(pledge.GetType());
                Console.ReadKey();
            }
            catch
            {
                throw new Exception("wrong boom!");
            }
        }
    }
}