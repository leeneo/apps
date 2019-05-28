using System;
using System.Collections.Generic;
using Newtonsoft.Json; //不要管红线提示，程序可以正常运行
using Microsoft.Extensions.Logging;

namespace CSharp {
    class Program {

        static void Main (string[] args) {
            //JsonTest.Run();
            // TestDate.OutPut();

            //字符串格式化输出--返回格式化字符串
            // StringFormat.OutPut ();

            // Console.WriteLine("DateTime.Now:" + DateTime.Now);
            // Console.WriteLine("DateTime.Now.ToShortDateString():" + DateTime.Now.ToShortDateString());
            // Console.WriteLine("DateTime.Now.ToLocalTime():" + DateTime.Now.ToLocalTime());
            // TryCatch.Run ();
            // var st = StringTest.NullTest = null;        //right:string 可以赋值为null
            // Console.WriteLine ("NullTest:" + st);
            // Console.WriteLine("NullTest:" + st.ToString());  //wrong:空引用异常
            // StringTest.getTest();

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

            // ActionFunc.TestMain();

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

            //MethodTest mt=new MethodTest();
            //var res=mt.Usp_get_next_no();
            //var res2=mt.Usp_get_next_no("测试");
            //Console.WriteLine("\nres:"+res+",res2:"+res2);

            // ConcurrentQueueTest.Run ();

            //YieldTest.Run();            

            // var l=new LogTest();
            // l.Run();

            //TaskTest.Run();
            // TaskTest.CreateTask();

            //System.Console.WriteLine(5%2);  //=>1

            // var b=new B();
            // b.Hello();
            // var bs=new B("小明","书");

            // var absb=new AbsB();
            // absb.Hello();
            // var absb2=new AbsB("小明","书");

            // var absa=new AbsA(); //报错：无法创建该类实例，抽象类不能被实例化

            // var c=new B.C();     //报错：访问级别不够，由此可见内部类与成员的默认访问级别一致为private

            // BubbleTest.Tolower();

            // ContainsTest.Opt();

            EqualsTest.Opt();

            Console.WriteLine ("\n" + DateTime.Now.ToString ("yyyy/MM/dd"));
            Console.ReadKey ();

        }
    }
}