//没有进行可空处理的代码
//Student s1 = GetData();
//Console.WriteLine(s1.Name.ToLower());
//Console.WriteLine(s1.PhoneNumber.ToLower());
//static Student GetData()
//{
//    Student s1 = new Student("Jacky");
//    s1.PhoneNumber = "999";
//    return s1;
//}

//对可空类型的成员进行检查
Student s1 = GetData();
Console.WriteLine(s1.Name.ToLower());
Console.WriteLine(s1.PhoneNumber ?? "手机号为空");

//确实值不可能为空之后，使用!抑制警告，慎用
//Console.WriteLine(s1.PhoneNumber!.ToLower());

static Student GetData()
{
    return new Student("tom");
}
