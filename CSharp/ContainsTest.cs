using System;

// namespace CSharp {
class ContainsTest {
    public static void Opt () {
        Console.WriteLine ("\"AO\".Contains(\"A\"): " + "AO".Contains ("A"));
        Console.WriteLine ("\"AO\".Contains(\"O\"): " + "AO".Contains ("O"));
        Console.WriteLine ("\"AO\".Contains(\"M\"): " + "AO".Contains ("M"));
    }
}
// }