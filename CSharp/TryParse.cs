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
                decimal.TryParse("0.01", out pledge);//С��1��ת��ʧ�ܣ���Ŀ������Ϊ0
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