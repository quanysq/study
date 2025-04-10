using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSample
{
    public class PCMain
    {

        // 创建一个线程安全的队列
        private static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        // 队列最大容量
        private static readonly int maxQueueSize = 5;

        // 协调生产者和消费者之间的操作
        private static AutoResetEvent itemsProcessed = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            Thread producer = new Thread(Produce);
            Thread consumer = new Thread(Consume);

            // 启动生产者线程
            producer.Start();

            // 启动消费者线程
            consumer.Start();

            // 等待生产者线程完成
            producer.Join();

            // 等待消费者线程完成
            consumer.Join();
        }

        /// <summary>
        /// 生产者
        /// </summary>
        static void Produce()
        {
            Random rand = new Random();

            // 生产者循环 20 次，每次随机等待一段时间
            for (int i = 0; i < 20; i++)
            {
                // 模拟生产时间
                Thread.Sleep(rand.Next(500));

                // 模拟生产数据
                while (true)
                {
                    // 如果队列未满，则调用 Enqueue 方法将数据添加到队列，
                    // 并使用 itemsProcessed.Set() 通知消费者
                    if (queue.Count < maxQueueSize)
                    {
                        // 将数据添加到队列
                        queue.Enqueue(i);
                        Console.WriteLine($"生产者生产了: {i}");
                        
                        // 通知消费者
                        itemsProcessed.Set(); 
                        break;
                    }
                    else
                    {
                        // 队列已满，生产者会等待一段时间（100ms）后重试
                        Console.WriteLine("队列已满，生产者等待...");
                        Thread.Sleep(100); 
                    }
                }
            }
        }

        /// <summary>
        /// 消费者
        /// </summary>
        static void Consume()
        {
            // 消费者循环 20 次，每次尝试从队列中取出数据
            for (int i = 0; i < 20; i++)
            {
                int item;
                while (true)
                {
                    // 使用 TryDequeue 尝试从队列中取出数据
                    if (queue.TryDequeue(out item)) 
                    {
                        // 取出并消费数据
                        // TODO 消费数据逻辑
                        Console.WriteLine($"消费者消费了: {item}");
                        break;
                    }
                    else
                    {
                        // 队列为空，消费者调用 itemsProcessed.WaitOne() 等待生产者发出信号
                        Console.WriteLine("队列为空，消费者等待...");
                        itemsProcessed.WaitOne(); 
                    }
                }
                Thread.Sleep(1000); // 模拟消费时间
            }
        }
    }
}
