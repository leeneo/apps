using System;

namespace CSharp {
    public abstract class AbsA {
        protected virtual string Name { get; set; }
        internal virtual int Count { get; set; }
        internal int Count2 { get; set; }

        public AbsA () {
            Console.WriteLine ("Init A");
        }
        public AbsA (string seller, string goods) {
            Console.WriteLine ("Init A:" + seller + " 卖了一样 " + goods);
        }
        public virtual void Hello () {
            Console.WriteLine ("A.Hello!");
        }
        public virtual void Selling () {        //可以不被子类重写
            Console.WriteLine ("A.Selling!");
        }
        // public virtual void Init () { }
        public abstract void Init ();
    }
}