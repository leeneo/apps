using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp {
    class TaskTest {
        /// <summary>
        /// 创建Task方式：new Task(),Task.Factory.StartNew(),Task.Run()
        ///Task.Run是等线程池空闲后再执行
        ///Task.Run 或 TaskFactory.StartNew（工厂创建） 方法是用于创建和计划的任务的首选的机制
        /// </summary>
        public static void CreateTask () {
            //传入Func委托
            Task<int> task = new Task<int> (a => { Console.WriteLine ("这是new Task<int>(Func<object,int> function)......"); return (int) a + 1; }, 1);
            task.Start ();
            Console.WriteLine (task.Result);

            //传入Action委托
            Task task1 = new Task (() => Console.WriteLine ("这是new Task(Action action)......"));
            task1.Start ();

            var task2 = Task.Factory.StartNew (() => { Console.WriteLine ("这是StartNew......"); return 1; });
            Console.WriteLine (task2.Result);

            var task3 = Task.Run (() => { Console.WriteLine ("这是Task.Run......"); return 1; });
            Console.WriteLine (task3.Result);

            //Task.ContinueWith(),类似于callback()
            var task4 = Task.Factory.StartNew<int> (() => { Console.WriteLine ("这是ContinueWith......"); return 1; });
            Console.WriteLine (task4.Result);
            var result = task4.ContinueWith<int> ((aa => { return aa.Result + 1; }));
            Console.WriteLine (result.Result);

        }
        public static void Test () {
            Task t1 = new Task (x => {
                //Task.Delay(5000);
                Console.WriteLine ("开始Task1！" + x);
            }, "123");
            Task<int> t2 = new Task<int> (a => { return (int) a + 1; }, 1);
            t1.Start ();
            t2.Start ();
            Console.WriteLine (t2.Result);
        }

        // 关于线程安全
        //这是线程不安全，直接调用外部参数
        static void UnSaveRun (string Name, int Age) {
            Task.Factory.StartNew (() => Console.WriteLine ("name:{0} age:{1}", Name, Age));
        }

        //如果你确定底层封装好了，可以像上面那样写，但建议写成下面这种
        static void SafeRun (string Name, int Age) {
            Task.Factory.StartNew (obj => {
                var o = (dynamic) obj;
                Console.WriteLine ("name:{0} age:{1}", o.Name, o.Age);
            }, new { Name, Age });
        }
    }
}