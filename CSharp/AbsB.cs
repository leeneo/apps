using System;

namespace CSharp {
    public class AbsB : AbsA {
        public AbsB () : base () { }   //通过base关键字调用基类中的无参构造方法
        public AbsB (string str1, string str2) : base (str1, str2) {   //通过base关键字调用基类中的有参构造方法
            Console.WriteLine("Init B:"+str1+" 卖了一本 "+str2);
        }
        public override void Hello () {     //重写继承自基类的成员时，访问级别需与基类保持一致
            base.Hello ();                  //通过base关键字调用基类中的方法
            Console.WriteLine ("B.Hello!");
        }
        public override void Init () {
            // base.Init ();  //报错：无法调用基类中的抽象方法
            Console.WriteLine ("B.Hello!");
        }
    }
}