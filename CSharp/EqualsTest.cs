using System;

namespace CSharp {
    //引用类型存储，引用变量的值存储在堆（Heap)中,在栈（stack）中存储该变量所占堆的地址，即变量的引用地址。
    class EqualsTest {
        static char[] a = new char[] { 'h', 'e', 'l', 'l', 'o' };
        static char[] b = new char[] { 'h', 'e', 'l', 'l', 'o' };

        static bool CompNum () {
            int i = 9;
            int j = 9;
            return i == j;
        }
        static bool EqualsNum () {
            int i = 9;
            int j = 9;
            return i.Equals (j);
        }
        static bool CompArray () {
            return a == b;
        }
        static bool EqualsArray () {
            return a.Equals (b);
        }
        static bool CompStr () {
            string i = new string (a);
            string j = new string (b);
            return i == j;
        }
        static bool EqualsStr () {
            string i = new string (a);
            string j = new string (b);
            return i.Equals (j);
        }
        static bool CompObj () {
            object i = (object) a;
            object j = (object) b;
            return i == j;
        }
        static bool EqualsObj () {
            object i = (object) a;
            object j = (object) b;
            return i.Equals (j);
        }
        static bool CompObj2 () {
            object i = 1;
            object j = 1;
            return i == j;
        }
        static bool EqualsObj2 () {
            object i = 1;
            object j = 1;
            return i.Equals (j);    //调用的是Int32.Equals() 只比较内容，所以是true
        }

        static bool CompClass () {
            var i = new Person ("小明");
            var j = new Person ("小明");
            return i == j;
        }
        static bool EqualsClass () {
            var i = new Person ("小明");
            var j = new Person ("小明");
            return i.Equals (j);
        }

        static bool CompClass2 () {
            var i = new Person ("小明");
            var j = i;
            return i == j;
        }
        static bool EqualsClass2 () {
            var i = new Person ("小明");
            var j = i;
            return i.Equals (j);
        }

        public static void Opt () {
            Console.WriteLine ("值类型比较");
            Console.WriteLine ("i==j：" + CompNum ());
            Console.WriteLine ("i.Equals(j)：" + EqualsNum ());
            Console.WriteLine ("====================================" + "\n");

            Console.WriteLine ("====================================");
            Console.WriteLine ("引用类型比较");
            Console.WriteLine ("====================================");

            Console.WriteLine ("字符串类型比较");
            Console.WriteLine ("i==j：" + CompStr ());
            Console.WriteLine ("i.Equals(j)：" + EqualsStr ());
            Console.WriteLine ("====================================");

            Console.WriteLine ("数组类型比较");
            Console.WriteLine ("i==j：" + CompArray ());
            Console.WriteLine ("i.Equals(j)：" + EqualsArray ());
            Console.WriteLine ("====================================");

            Console.WriteLine ("实体类型比较");
            Console.WriteLine ("i==j：" + CompClass ());
            Console.WriteLine ("i.Equals(j)：" + EqualsClass ());
            Console.WriteLine ("i==j：" + CompClass2 ());
            Console.WriteLine ("i.Equals(j)：" + EqualsClass2 ());
            Console.WriteLine ("====================================");

            Console.WriteLine ("Object类型比较");
            Console.WriteLine ("i==j：" + CompObj ());
            Console.WriteLine ("i.Equals(j)：" + EqualsObj ());
            Console.WriteLine ("i==j：" + CompObj2 ());
            Console.WriteLine ("i.Equals(j)：" + EqualsObj2 ());
            Console.WriteLine ("====================================");
        }
    }

    class Person {
        public string Name { get; set; }
        public Person (string name) {
            Name = name;
        }
    }
}