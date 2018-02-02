using System;
using System.Collections.Generic;

namespace CSharp {
    class StringTest {

       
        // public static string? NullableTest { get; set; } // wrong:类型“string”必须是不可以为 null 值的类型
        public static string NullTest { get; set; } //NullTest=null;string 可赋值为null
        public static void getTest () {
            Console.WriteLine ("Test");
        }
    }
}
