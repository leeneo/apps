using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CSharp {
    class YieldTest {

        public static void Run () {
            Console.WriteLine ("不使用 yield return 方式的结果");
            foreach (var item in WithoutYield ()) {
                Console.WriteLine (item);
            }
            Console.WriteLine ("使用 yield return 方式的结果");
            foreach (var item in WithYield ()) {
                Console.WriteLine (item);
            }
            Console.ReadLine ();
        }

        /// <summary>
        /// 不使用 yield return
        /// </summary>
        /// <returns></returns>
        static IEnumerable<int> WithoutYield () {
            List<int> result = new List<int> ();
            foreach (int i in GetData ()) {
                if (i > 2) {
                    result.Add (i);
                    // return i;
                }
            }
            return result;
        }
        /// <summary>
        /// 使用 yield return
        /// </summary>
        /// <returns></returns>
        static IEnumerable<int> WithYield () {
            foreach (int i in GetData ()) {
                if (i > 2) {
                    yield return i;
                }
            }
            yield break;
            Console.WriteLine ("这里的代码不执行");
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        static List<int> GetData () {
            return new List<int> () { 1, 2, 3, 4 };
        }
    }
}