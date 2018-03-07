using System;

namespace CSharp {

    delegate int calculator (int x, int y); // 委托
    
    ///委托和匿名方法，Lamda表达式的使用对比
    public class LamdaExpression {

        // 1,委托使用
        public static void DelTest (int a, int b) {
            calculator cal = new calculator (Adding);
            int num = cal (a, b);
            Console.WriteLine (num);
        }
        static int Adding (int x, int y) {
            return x + y;
        }

        // 2，匿名方法
        public static void AnonymityTest (int a, int b) {
            calculator cal = delegate (int x, int y) {
                return x + y;
            };
            int num = cal (a, b);
            Console.WriteLine (num);
        }

        // 3，lamda表达式
        public static void LamdaTest (int a, int b) {
            calculator cal = (x, y) => x + y;
            int num = cal (a, b);
            Console.WriteLine (num);
        }
    }
}