Task WriteFileAsync(int num, string content)
{
    switch (num)
    {
        case 1:
            return File.WriteAllTextAsync("d:/1.txt", content);
        case 2:
            return File.WriteAllTextAsync("d:/1.txt", content);
        default:
            Console.WriteLine("文件暂时不可用");
            // 返回Task.CompletedTask对象，表示方法调用结束
            return Task.CompletedTask;
    }
}

Task<string> ReadFileAsync(int num)
{
    switch (num)
    {
        case 1:
            return File.ReadAllTextAsync("d:/1.txt");
        case 2:
            return File.ReadAllTextAsync("d:/2.txt");
        default:
            // 用Task.FromResult方法把需要返回的值转换为Task对象
            return Task.FromResult("Love");
    }
}

await WriteFileAsync(0, "hello");
string s1 = await ReadFileAsync(5);
Console.WriteLine(s1);