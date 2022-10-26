Console.WriteLine("before write file");
string fileName = @"D:\Work\study\TestProject_VS2022\NetCore\ASP.NETCore技术内幕与项目实战\02\1.txt";
await File.WriteAllTextAsync(fileName, "hello async");
Console.WriteLine("before read file");
string s = await File.ReadAllTextAsync(fileName);
Console.WriteLine(s);
