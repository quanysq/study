string s1 = await ReadFileAsync(1);
Console.WriteLine(s1);

Task<string> ReadFileAsync(int num)
{
    switch (num)
    {
        case 1:
            return File.ReadAllTextAsync("d:/1.txt");
        case 2:
            return File.ReadAllTextAsync("d:/2.txt");
        default:
            throw new ArgumentException("num invalid");
    }
}

/*
 *  只要方法的返回值是Task类型，我们就可以用await关键字对其进行调用，而不用管被调用的方法是否用async修饰
 *  这样可以提高效率
 */

