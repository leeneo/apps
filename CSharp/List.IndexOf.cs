using System;
using System.Collections.Generic;

namespace CSharp {
    public class ListIndexOf {
        public static void Run () {
            List<string> dinosaurs = new List<string> ();
            
            dinosaurs.Add ("Tyrannosaurus");
            dinosaurs.Add ("Amargasaurus");
            dinosaurs.Add ("Mamenchisaurus");
            dinosaurs.Add ("Brachiosaurus");
            dinosaurs.Add ("Deinonychus");
            dinosaurs.Add ("Tyrannosaurus");
            dinosaurs.Add ("Compsognathus");

            foreach (string dinosaur in dinosaurs) {
                Console.WriteLine (dinosaur);
            }
            //List.IndexOf(T); 从零开始索引
            Console.WriteLine ("IndexOf(\"Tyrannosaurus\"): {0}",
                dinosaurs.IndexOf ("Tyrannosaurus"));
            //List.IndexOf(T,index); 指定从index处开始索引，没有返回-1
            Console.WriteLine ("IndexOf(\"Tyrannosaurus\", 6): {0}",
                dinosaurs.IndexOf ("Tyrannosaurus", 6));
            //List.IndexOf(T,a,b); 指定在a-b范围内索引，没有返回-1
            Console.WriteLine ("IndexOf(\"Tyrannosaurus\", 2, 5): {0}",
                dinosaurs.IndexOf ("Tyrannosaurus", 2, 5));
        }
    }
}
