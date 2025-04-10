// ====================生产者-消费者模式==================
using QueueSample;

PCMain.Main(null);

// ====================普通用法==================
/*
// 创建一个字符串队列
Queue<string> queue = new Queue<string>();

// 入队操作
Console.WriteLine("添加 3 个打印任务到队列......");
queue.Enqueue("打印任务 1");
queue.Enqueue("打印任务 2");
queue.Enqueue("打印任务 3");

Console.WriteLine(queue.Contains("打印任务 2"));

Console.WriteLine("查看当前队列: ");
foreach (string item in queue)
{
    Console.WriteLine($"队列：{item}");
}
Console.WriteLine();

// 查看队首元素但不移除
Console.WriteLine("查看当前队首元素: " + queue.Peek());
Console.WriteLine();

// 依次处理前两个打印任务
Console.WriteLine($"处理第1个打印任务: {queue.Dequeue()}");
Console.WriteLine($"处理第2个打印任务: {queue.Dequeue()}");
Console.WriteLine();

Console.WriteLine("重新查看当前队列: ");
foreach (string item in queue)
{
    Console.WriteLine($"队列：{item}");
}
Console.WriteLine();

// 清空队列
Console.WriteLine("清空队列");
queue.Clear();
Console.WriteLine($"队列是否为空: {queue.Count == 0}");
*/