using System;
using System.Collections.Generic;
using Newtonsoft.Json;//不要管红线提示，程序可以正常运行

namespace CSharp {
    class JsonTest {
        
        public static void Run () {
            string str = "{'name':'wwii','age':28}";
            var obj = JsonConvert.DeserializeObject(str);
            Console.WriteLine ("json对象:"+obj);
            var jon = JsonConvert.SerializeObject(obj);
            Console.WriteLine("json字符串："+jon);
        }
    }
}