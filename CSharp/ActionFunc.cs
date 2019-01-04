using System;
namespace CSharp {

    /*  Action 与 Func是.NET类库中增加的内置委托，以便更加简洁方便的使用委托。
        内置委托类型，顾名思义Action和Func本身就是已经定义好的委托类型。
        两种委托类型的区别在于：Action委托签名不提供返回类型，而Func提供返回类型。
        Action委托具有Action<T>、Action<T1,T2>、Action<T1,T2,T3>……Action<T1,……T16>多达16个的重载，其中传入参数均采用泛型中的类型参数T，涵盖了几乎所有可能存在的无返回值的委托类型。Func则具有Func<TResult>、Func<T,Tresult>……Func<T1,T2,T3……,Tresult>17种类型重载，T1……T16为出入参数，Tresult为返回类型
     */

    public delegate int Math (int param1, int param2); //基本形式
    public class ActionFunc {

        // 定义委托类型
        public static int Add (int param1, int param2) //定义同签名函数,有返回结果
        {
            return param1 + param2;
        }
        public static void Minus (int param1, int param2) //定义同签名函数，无返回结果
        {
            System.Console.WriteLine (param1 - param2);
        }

        public static int TestFunc () { 
            Func<int, int, int> math = Add;     //指定委托对象并关联函数                        
            return math (1, 2);                 //调用委托函数;
        }
        public static int TestFunc2 (int a, int b) { 
            // 匿名函数：
            Func<int, int, int> math = delegate (int param1, int param2) {
                return param1 + param2;
            };
            return math (a, b);
        }
        public static int TestFunc3 (int a, int b) {
            // Lambda：
            Func<int, int, int> math = (param1, param2) => {
                return param1 + param2;
            };
            return math (a, b);
        }
        public static void TestAction () {
            Action<int, int> math = Minus;      //指定委托对象并关联函数
            math (2, 1);                        //调用委托函数
        }
        public static void TestAction2 (int a, int b) {
            // 匿名函数：
            Action<int, int> math = delegate (int x, int y) {
                System.Console.WriteLine (x - y);
            };
            math (a, b); 
        }
        public static void TestAction3 (int a, int b) {
            // Lambda：
            Action<int, int> math = (x, y) => {
                System.Console.WriteLine (x - y);
            };
            math (a, b); 
        }
        public static void TestMain () {
            System.Console.WriteLine (ActionFunc.TestFunc ());
            System.Console.WriteLine (ActionFunc.TestFunc2 (1, 2));
            System.Console.WriteLine (ActionFunc.TestFunc3 (1, 2));
            ActionFunc.TestAction ();
            ActionFunc.TestAction2 (2, 1);
            ActionFunc.TestAction3 (2, 1);
        }
    }
}