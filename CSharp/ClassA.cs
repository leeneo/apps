using System;

// namespace CSharp {
    class A {
        public string Name { get{return "A.Name";} set{} }
        string Age { get; set; }

        protected A () {
            Console.WriteLine ("Init A");
        }
        public A (string seller, string goods) {
            Console.WriteLine ("Init A:" + seller + " 卖了一样 " + goods);
        }
        public virtual void Hello () {
            Console.WriteLine ("A.Hello!");
        }
        public virtual void Selling () {
            Console.WriteLine ("A.Selling!");
        }
        public void Selling2 () {
            Console.WriteLine ("A.Selling!");
        }
    }
// }