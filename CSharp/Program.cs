using System;
using System.Collections.Generic;
using Newtonsoft.Json; //不要管红线提示，程序可以正常运行

namespace CSharp {
    class Program {

        static void Main (string[] args) {
            //JsonTest.Run();
            Console.WriteLine ("ShortDate:" + TestDate.ShortDate ());
            Console.WriteLine ("ShortTime:" + TestDate.ShortTime ());
            Console.WriteLine ("LongTime:" + TestDate.LongTime ());
            Console.WriteLine ("LongDate:" + TestDate.LongDate ());
            Console.WriteLine ("LocalTime:" + TestDate.LocalTime ());
            Console.WriteLine ("UniversalTime:" + TestDate.UniversalTime ());
            Console.WriteLine ("ToString:" + TestDate.ToString ());
            Console.WriteLine ("Date:" + TestDate.Date ());

            TryCatch.Run ();

            Console.ReadKey ();

        }
    }
}