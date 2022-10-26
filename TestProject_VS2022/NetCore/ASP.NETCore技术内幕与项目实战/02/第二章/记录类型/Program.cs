// record 可以直接判断同一个类型的两个对象是否相等
Person p1 = new Person("Zack", "Yang");
Person p2 = new Person("Zack", "Yang");
Person p3 = new Person("Kim", "Yoo");
Console.WriteLine(p1);
Console.WriteLine(p1 == p2);
Console.WriteLine(p1 == p3);
Console.WriteLine(p1.FirstName);

// record 高级用法
Student s1 = new Student("Yang");
Student s2 = new Student("Yang ");
Console.WriteLine(s1);
Console.WriteLine(s1 == s2);
s1.FirstName = "Zack";
s1.SayHello();
Console.WriteLine(s1 == s2);

User u1 = new User("Zack", 18);
User u2 = new User("Zack", "yzk@example.com", 18);
User u3 = new User(u1.UserName, "test@example", u1.Age);
User u4 = u1 with { Email = "test1@example" }; // with 关键字
Console.WriteLine(u2);
Console.WriteLine(u1);
Console.WriteLine(u3);
Console.WriteLine(u4);
Console.WriteLine(Object.ReferenceEquals(u1, u4));
