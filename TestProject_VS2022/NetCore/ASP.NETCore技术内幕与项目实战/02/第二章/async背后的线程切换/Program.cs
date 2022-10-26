using System.Text;

string file1 = "async1.txt";
string file2 = "async2.txt";
string file3 = "async3.txt";
// Path: D:\Work\study\TestProject_VS2022\NetCore\ASP.NETCore技术内幕与项目实战\02\第二章\async背后的线程切换\bin\Debug\net6 .0\async1.txt

Console.WriteLine($"1-ThreadId={Thread.CurrentThread.ManagedThreadId}");
string str = new string('a', 10000000);
await File.WriteAllTextAsync(file1, str);
Console.WriteLine($"2-ThreadId={Thread.CurrentThread.ManagedThreadId}");
await File.WriteAllTextAsync(file2, str);
Console.WriteLine("3-ThreadId=" + Thread.CurrentThread.ManagedThreadId);
File.WriteAllText(file3, str);
Console.WriteLine("4-ThreadId=" + Thread.CurrentThread.ManagedThreadId);
//Console.WriteLine(Path.GetFullPath(file3));

/*
* Result:
* 1-ThreadId=1
* 2-ThreadId=4
* 3-ThreadId=12
* 4-ThreadId=12
*/

