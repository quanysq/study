using System.Diagnostics;

// 创建一个随机数数组
var numbers = GenerateRandomNumbers(1000000);

// 创建一个 Stopwatch 实例
var stopwatch = new Stopwatch();

// 开始计时
stopwatch.Start();

// 排序数组
SortNumbers(numbers);

// 停止计时
stopwatch.Stop();

// 输出结果
Console.WriteLine($"Sorting took {stopwatch.ElapsedMilliseconds} milliseconds.");

Console.ReadKey();


// 生成随机数数组
static int[] GenerateRandomNumbers(int count)
{
    var random = new Random();
    var numbers = new int[count];
    for (int i = 0; i < count; i++)
    {
        numbers[i] = random.Next(1, 1000000);
    }
    return numbers;
}

// 排序函数
static void SortNumbers(int[] numbers)
{
    // 这里简单使用 Array.Sort
    Array.Sort(numbers);
}

// 元组

// 调用 GetBookInfo 方法并解构元组
(string title, string author, int year) = GetBookInfo();

// 输出书籍信息
Console.WriteLine($"书名: {title}, 作者: {author}, 出版年份: {year}");

/// <summary>
/// 获取书籍信息的方法，返回一个包含书名、作者和出版年份的元组。
/// </summary>
/// <returns>包含书籍信息的元组。</returns>
static (string, string, int) GetBookInfo()
{
    return ("老杨的 C# 编程指南", "老杨", 2024);
}