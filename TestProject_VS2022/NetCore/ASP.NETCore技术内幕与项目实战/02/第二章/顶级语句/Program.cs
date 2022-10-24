// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// 在顶级语句中，可以直接使用await语法调用异步方法，
// 而且在顶级语句文件中也可以声明方法
int i = 1, j = 2;
int w = Add(i, j);
await File.WriteAllTextAsync(@"D:\Work\study\TestProject_VS2022\NetCore\ASP.NETCore技术内幕与项目实战\02\1.txt", $"Hellow {w}");
int Add(int i, int j)
{
    return i + j;
}
