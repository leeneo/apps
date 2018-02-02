using System;
using System.Collections.Generic;
using Newtonsoft.Json; //不要管红线提示，程序可以正常运行

namespace CSharp {
    class Program {

        static void Main (string[] args) {
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
            string date = DateTime.Now.ToString("yyyy#MM#dd");
            StringTest.NullTest=null;
            Console.WriteLine("NullTest:" + StringTest.NullTest);
            Console.WriteLine(date);

            Console.ReadKey ();

        }
    }
}