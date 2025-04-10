using System.Threading.Channels;

// 初始化一个无界 Channels
//var channel = Channel.CreateUnbounded<int>();

// 创建一个有界通道，最大容量为10
var channel = Channel.CreateBounded<int>(new BoundedChannelOptions(10)
{
    FullMode = BoundedChannelFullMode.Wait,     // 当通道已满时，等待直到有空间
    SingleReader = true,                        // 设置单个读者
    SingleWriter = false                        // 允许多个写入者
});

// 启动生产者
var producerTask = ProduceNumbers(channel.Writer);

// 启动消费者
var consumerTask = ConsumeNumbers(channel.Reader);

await Task.WhenAll(producerTask, consumerTask);

static async Task ProduceNumbers(ChannelWriter<int> writer)
{
    for (int i = 1; i <= 10; i++)
    {
        // 模拟生产时间
        await Task.Delay(500);

        // 尝试将数据写入通道
        await writer.WriteAsync(i);
        Console.WriteLine($"生产者产生: {i}");
    }
    writer.Complete(); // 完成写入
}

static async Task ConsumeNumbers(ChannelReader<int> reader)
{

    await foreach (var number in reader.ReadAllAsync())
    {
        // 模拟消费时间
        await Task.Delay(1000);
        Console.WriteLine($"消费者处理: {number * number}");
    }
}
