using System;
using System.Collections.Generic;
using Newtonsoft.Json; //不要管红线提示，程序可以正常运行

namespace CSharp {
    class Program {

        static void Main (string[] args) {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            //JsonTest.Run();
            // Console.WriteLine ("ShortDate:" + TestDate.ShortDate ());
            // Console.WriteLine ("ShortTime:" + TestDate.ShortTime ());
            // Console.WriteLine ("LongTime:" + TestDate.LongTime ());
            // Console.WriteLine ("LongDate:" + TestDate.LongDate ());
            // Console.WriteLine ("LocalTime:" + TestDate.LocalTime ());
            // Console.WriteLine ("UniversalTime:" + TestDate.UniversalTime ());
            // Console.WriteLine ("ToString:" + TestDate.ToString ());
            // Console.WriteLine ("Date:" + TestDate.Date ());
            // Console.WriteLine("DateTime.Now:" + DateTime.Now);
            // Console.WriteLine("DateTime.Now.ToShortDateString():" + DateTime.Now.ToShortDateString());
            // Console.WriteLine("DateTime.Now.ToLocalTime():" + DateTime.Now.ToLocalTime());
            // TryCatch.Run ();
            // StringTest.NullTest=null;
            // Console.WriteLine("NullTest:" + StringTest.NullTest.ToString());

            //object msg=StringTest.Messages="Test";
            //msg = null;
            //Console.WriteLine(string.IsNullOrEmpty(msg.toStirng()));//wrong:判断可能为空Object类型时不能用obj.toString();
            //Console.WriteLine(string.IsNullOrEmpty((string)msg));//right:判断可能为空Object类型时不能用obj.toString();            

            // Console.WriteLine(255%256);  //255;求余

            // LamdaExpression.DelTest(2,5);
            // LamdaExpression.AnonymityTest(2,2);
            // LamdaExpression.LamdaTest(1,2);

            // DelegateTest.UseDel();
            // DelegateTest.TestMain();

            // EnumTest.GreetPeople("小小",EnumTest.Language.Chinese);
            // EnumTest.GreetPeople("Mike",EnumTest.Language.English);

            //ObserveDesign.TestMain();

            //get;set 访问器测试
            //Student a = new Student();
            //a.Str = "果子";
            //Console.WriteLine(a.Str);

            //TryParse.Run();

            // Byte[] b = TestBytes.GetBytes("456");
            // foreach(var i in b)
            // {
            //     Console.WriteLine(i);
            // }
            // Console.WriteLine("byteStr:" + TestBytes.GetByteStr("456"));
            // Console.WriteLine("str1:" + TestBytes.GetStr(b));
            // Console.WriteLine("str2:" + TestBytes.GetStr("53-54-55-"));          

            MethodTest mt=new MethodTest();
            var res=mt.Usp_get_next_no("123");
            Console.WriteLine("\n"+res);

            Console.WriteLine("\n"+date);
            Console.ReadKey ();

        }
    }
}