using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    //队列（Queue）代表了一个先进先出的对象集合。当您需要对各项进行先进先出的访问时，则使用队列。当您在列表中添加一项，称为入队，当您从列表中移除一项时，称为出队。
    //ConcurrentQueue<T>队列是一个高效的线程安全的队列，是.Net Framework 4.0，System.Collections.Concurrent命名空间下的一个数据结构。 //对列的使用场景有很多。所有要异步处理的都可以使用对列的方式。如接口日志异步处理，邮件、短信异步发送等。对列一般配合单例设计模式和线程一起使用更佳。
    
    class ConcurrentQueueTest
    {
        // 对列初始化：
        
        ConcurrentQueue<ApiLogContract> Queue = new ConcurrentQueue<ApiLogContract>();
        
        /// <summary>
        /// 单条入队列
        /// </summary>
        /// <param name="model">入列模型</param>
        
        Queue.Enqueue(model);     
                
        /// <summary>
        /// 多条入队
        /// </summary>
        /// <param name="list"></param>
        
        List<ApiLogContract> list = new List<ApiLogContract>();
        
        list.add(new model{});
        
        list.add(new model{});
        
        list.add(new model{});
        
        list.add(new model{});
        
        list.ForEach(t => Enqueue(t));       
        
        
        /// <summary>
        /// 单条出队
        /// </summary>
        /// <returns></returns>
        
        ApiLogContract apiLog = null;
        Queue.TryDequeue(out apiLog);        
        
        
        /// <summary>
        /// 多条出队
        /// </summary>
        /// <param name="count">数量</param>
        /// <returns></returns>
        
        var logs = new List<ApiLogContract>();
        
        if (Queue.Count > 0)
        {
        　　for (int i = 0; i < count; i++)
        　　{
        　　　　var source = Dequeue();
        　　　　if (source != null)
        　　　　{
        　　　　　　logs.Add(source);
        　　　　}
        　　}
        }

        /// <summary>
        /// 获取对列数量
        /// </summary>
        /// <returns></returns>
        Queue.Count

        /// <summary>
        /// 确定序列是否包含任何元素[用于判断对列是否有要处理的数据]这个方法的性能比Count()方法快
        /// </summary>
        /// <returns></returns>
        Queue.Any()
    }
}
