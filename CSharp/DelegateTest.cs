using System;
namespace CSharp {

    // 委托是一种封装方法的类型（类似于类），定义了所代表的方法的类型，使方法可以作为参数传递
    // 最初使用委托时，均需要先定义委托类型，然后定义一个符合委托参数类型（签名）的函数
    public delegate void GreetingDelegate (string name); //定义委托类型
    public delegate void SumDelegate (int num); //定义委托类型

    public class DelegateTest {
        static void EnglishGreeting (string name) {     //定义同名函数
            Console.WriteLine ("Moring," + name);
        }
        static void ChineseGreeting (string name) {     //定义同名函数
            Console.WriteLine ("早上好," + name);
        }
        static void SumSomeNum (int num) {              //定义同名函数
            Console.WriteLine ("人数：" + num);
        }

        static void GreetPeople (string name, GreetingDelegate MakeGreeting) {      
            MakeGreeting (name);
        }
        static void SumPeople (int num, SumDelegate MakeGreeting) {                 
            MakeGreeting (num);
        }

        // 委托的基本使用
        public static void UseDel () {
            GreetingDelegate grd = new GreetingDelegate(ChineseGreeting);   //创建委托对象，与指定同名函数进行关联
            // GreetingDelegate grd=ChineseGreeting;                        //简化形式 
            grd ("Kids");
        }
        // 将方法作为参数调用
        public static void TestMain () {
            GreetingDelegate grtdel=EnglishGreeting;  
            // 一个委托对象，可以绑定多个方法，必需先赋值再绑定(+=),直接绑定会报错
            grtdel+=ChineseGreeting;
            GreetPeople("Jim",grtdel);
            grtdel-=EnglishGreeting;
            GreetPeople("小凡",grtdel);

            // GreetPeople ("Jim", EnglishGreeting);
            SumPeople (25, SumSomeNum);
        }
    }
}