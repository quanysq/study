// See https://aka.ms/new-console-template for more information
Console.WriteLine("请输入第 1 个数字：");
string a = Console.ReadLine();
Console.WriteLine("请输入第 2 个数字：");
string b = Console.ReadLine();
Console.WriteLine("第 1 个和第 2 个数字的和：");
string c = (int.Parse(a) + int.Parse(b)).ToString();
Console.WriteLine(c);


