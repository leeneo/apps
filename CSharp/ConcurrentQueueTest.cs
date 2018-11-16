using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Reflection;
using System;

namespace CSharp
{
    //队列（Queue）代表了一个先进先出的对象集合。当您需要对各项进行先进先出的访问时，则使用队列。当您在列表中添加一项，称为入队，当您从列表中移除一项时，称为出队。
    //ConcurrentQueue<T>队列是一个高效的线程安全的队列，是.Net Framework 4.0，System.Collections.Concurrent命名空间下的一个数据结构。 //对列的使用场景有很多。所有要异步处理的都可以使用对列的方式。如接口日志异步处理，邮件、短信异步发送等。对列一般配合单例设计模式和线程一起使用更佳。       
    class ApiLogContract
    {
        public int Index { get; set; }
        public string Name { get; set; }
    }

    public class ConcurrentQueueTest
    {
        public static void Run()
        {        // 对列初始化：

            ConcurrentQueue<ApiLogContract> Queue = new ConcurrentQueue<ApiLogContract>();
            ApiLogContract item = new ApiLogContract { Index = 0, Name = "Name0" };

            /// <summary>
            /// 单条入队
            /// </summary>
            /// <param name="model">入列模型</param>
            Queue.Enqueue(item);
            Console.WriteLine("入队：" + item.Name);
            Console.WriteLine(Queue.Count);

            /// <summary>
            /// 单条出队
            /// </summary>
            /// <returns></returns>
            //ApiLogContract apiLog = null;
            Queue.TryDequeue(out item);
            Console.WriteLine("出队：" + item.Name);
            Console.WriteLine(Queue.Count+"\n\r");

            /// <summary>
            /// 多条入队
            /// </summary>
            /// <param name="list"></param>
            List<ApiLogContract> list = new List<ApiLogContract>();
            list.Add(new ApiLogContract { Index = 1, Name = "Name1" });
            list.Add(new ApiLogContract { Index = 2, Name = "Name2" });
            list.Add(new ApiLogContract { Index = 3, Name = "Name3" });
            list.Add(new ApiLogContract { Index = 4, Name = "Name4" });
            list.ForEach(t => Queue.Enqueue(t));

            foreach (var i in list)
            {
                Console.WriteLine("入队：" + i.Name);
                Console.WriteLine(Queue.Count);
            }
            Console.WriteLine("\n");

            /// <summary>
            /// 多条出队
            /// </summary>
            /// <param name="count">数量</param>
            /// <returns></returns>
            var logs = new List<ApiLogContract>();
            var log = new ApiLogContract();

            if (Queue.Count > 0)
            {
                ApiLogContract iLogs = null;
                for (int i = 0; i < list.Count; i++)
                {
                    log = list[i];
                    var source = Queue.TryDequeue(out iLogs);
                    if (source)
                    {
                        logs.Add(log);
                    }
                }
            }

            foreach (var i in logs)
            {
                Console.WriteLine("出队：" + i.Name);
                Console.WriteLine(Queue.Count);
            }

            /// <summary>
            /// 获取对列数量
            /// </summary>
            /// <returns></returns>
            // Console.WriteLine(Queue.Count);

            /// <summary>
            /// 确定序列是否包含任何元素[用于判断对列是否有要处理的数据]这个方法的性能比Count()方法快
            /// </summary>
            /// <returns></returns>
            // Console.WriteLine(Queue.IsEmpty);
        }
    }
}