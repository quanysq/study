using PatternMatchingDemo;


var point = (x: 10, y: 20);

switch (point)
{
    case (0, 0):
        Console.WriteLine("Origin");
        break;
    case (var x, 0):
        Console.WriteLine($"On X-axis at ({x}, 0)");
        break;
    case (0, var y):
        Console.WriteLine($"On Y-axis at (0, {y})");
        break;
    case (var x, var y):
        Console.WriteLine($"Point at ({x}, {y})");
        break;
}


var time = DateTime.Now;
switch (time)
{
    case { Year: 2023 or 2024, Month: <= 12, Day: 12 } t:
        Console.WriteLine($"the first day of every month in the first half of 2020 and 2021");
        break;
}

// 创建不同类型的消息实例
var messages = new MyMessage[]
{
    new TextMessage("你好，模式匹配！"),
    new EmailMessage("example@example.com", "主题", "邮件正文"),
    new AlertMessage("警告：服务器即将重启")
};

// 遍历消息数组并处理每个消息
foreach (var message in messages)
{
    HandleMessage(message);
}

/// <summary>
/// 处理不同类型的消息。
/// </summary>
/// <param name="message">要处理的消息对象。</param>
static void HandleMessage(MyMessage message)
{
    switch (message)
    {
        case TextMessage txtMsg:
            Console.WriteLine("处理文本消息: ");
            Console.WriteLine(txtMsg.Content);
            Console.WriteLine();
            break;
        case EmailMessage emailMsg when emailMsg.To=="Jacky":
            Console.WriteLine("处理电子邮件消息: ");
            Console.WriteLine($"发送到 {emailMsg.To}, 主题: {emailMsg.Subject}, 正文: {emailMsg.Body}");
            Console.WriteLine();
            break;
        case EmailMessage emailMsg when emailMsg.To == "Jacky" && emailMsg.Subject=="Handle Bug #809":
            Console.WriteLine("处理电子邮件消息: ");
            Console.WriteLine($"发送到 {emailMsg.To}, 主题: {emailMsg.Subject}, 正文: {emailMsg.Body}");
            Console.WriteLine();
            break;
        case EmailMessage emailMsg when emailMsg.To == "Yang":
            break;
        case AlertMessage alertMsg:
            Console.WriteLine("处理警告消息: ");
            Console.WriteLine(alertMsg.Message);
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("未知类型的消息");
            break;
    }
}