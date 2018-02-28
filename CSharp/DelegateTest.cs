using System;
namespace CSharp {

    // 委托是一种封装方法的类型（类似于类），定义了所代表的方法的类型，使方法可以作为参数传递
    public delegate void GreetingDelegate (string name); //委托的声明
    public delegate void SumDelegate (int num); //委托的声明

    public class DelegateTest {


        static void EnglishGreeting (string name) {
            Console.WriteLine ("Moring," + name);
        }
        static void ChineseGreeting (string name) {
            Console.WriteLine ("早上好," + name);
        }
        static void SumSomeNum (int num) {
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
            GreetingDelegate grd=ChineseGreeting;
            // ==> GreetingDelegate grd = new GreetingDelegate(ChineseGreeting);   
            grd ("托儿");
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