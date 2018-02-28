using System;
namespace CSharp {

    public class EnumTest {

        public enum Language {
            English,
            Chinese
        }

        static void EnglishGreeting (string name) {
            Console.WriteLine ("Moring," + name);
        }
        static void ChineseGreeting (string name) {
            Console.WriteLine ("早上好," + name);
        }
        public static void GreetPeople (string name, Language lan) {
            switch (lan) {
                case Language.English:
                    EnglishGreeting (name);
                    break;
                case Language.Chinese:
                    ChineseGreeting (name);
                    break;
            }
        }
    }
}