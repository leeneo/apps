using System;

namespace CSharp {
    internal class B : A {
        internal B () : base () { } //通过base关键字调用基类中的无参构造方法
        public B (string str1, string str2) : base (str1, str2) { //通过base关键字调用基类中的有参构造方法
            Console.WriteLine ("Init B:" + str1 + " 卖了一本 " + str2);
            Console.WriteLine("继承自基类的："+base.Name);      //使用继承自基类的成员
            // Console.WriteLine(base.Age);       //报错：A.Age对子类不可见
        }
        public override void Hello () {
            base.Hello (); //通过base关键字调用基类中的方法
            Console.WriteLine ("B.Hello!");
            var c=new C();
            c.Say();            
            // c.Said();    //访问级别不够,外部类仅能访问内部类的 public和 internal成员。       
            C.Silence();            
        }
        // public override void Selling2 () {      //报错：基类中该方法未标记为virtual,abstract,override，无法被重写
        //     Console.WriteLine ("B.Selling2!");
        // }

        class C {
            public C () { }
            internal void Say () {
                Console.WriteLine ("C.Say()");
            }

            private void Said () {
                Console.WriteLine ("C.Said()");
            }
            internal static void Silence () {
                Console.WriteLine ("C.Said()");
            }

            ~C () {
                Console.WriteLine ("析构函数！");
            }
        }

    }
}