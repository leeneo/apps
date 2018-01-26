using Newtonsoft.Json;
using System;

namespace CSharp {
    class TryCatch {

        public static void Run () {
            try {
                string str = "{'name':'wwii','age':28}";
                var obj = JsonConvert.DeserializeObject (str);
                Console.WriteLine ("json对象:" + obj);
                var jon = JsonConvert.SerializeObject (obj);
                Console.WriteLine ("json字符串：" + jon);

            } catch  {
                throw new Exception("wrong boom!");
            }
        }
    }
}