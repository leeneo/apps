using System;

namespace CSharp {
    class GetAscii {
        public static void Opt () {
            Console.WriteLine ("请输入一个值:");
            string str = Console.ReadLine ();

            int result;
            if (!int.TryParse (str, out result)) {
                Console.WriteLine ("输入值转换Int类型失败");
            } else
                Console.WriteLine (str + " 的Int形式：" + result);

            char c;
            if (!char.TryParse (str, out c)) {
                Console.WriteLine ("输入值转换Char类型失败");
            } else {
                Console.WriteLine (str + " 的Char形式：" + c);
                int i = (int) c;
                Console.WriteLine (str + " 的Ascii形式：" + i);
            }

        }
    }
}1