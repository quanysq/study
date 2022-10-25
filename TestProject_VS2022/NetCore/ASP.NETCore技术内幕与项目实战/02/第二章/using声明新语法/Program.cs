using Microsoft.Data.SqlClient;

string connStr = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ContosoUniversity1;Integrated Security=SSPI;";
string file = @"D:\Work\study\TestProject_VS2022\NetCore\ASP.NETCore技术内幕与项目实战\02\1.txt";

//OldUsing();
//NewUsing();

NewUsingWithErrorFix();

// 旧的写法
void OldUsing()
{
    using (var conn = new SqlConnection(connStr))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select * from Student";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                }
            }
        }
    }
}


// 新的写法
void NewUsing()
{
    using var conn = new SqlConnection(connStr);
    conn.Open();
    using var cmd = conn.CreateCommand();
    cmd.CommandText = "select * from Student";
    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader.GetString(1));
    }
}

// using 新写法的陷阱
void NewUsingWithError()
{
    using var outStream = File.OpenWrite(file);
    using var writer = new StreamWriter(outStream);
    writer.WriteLine("hello");
    string s = File.ReadAllText(file); //执行这一行时，文件还被占用中，会出错
    Console.WriteLine(s);
}

void NewUsingWithErrorFix()
{
    // 添加一个花括号构建了一个独立的代码块，形成一个独立的作用域
    // 离开这个作用域时，两个 using 指向的对象会释放
    {
        using var outStream = File.OpenWrite(file);
        using var writer = new StreamWriter(outStream);
        writer.WriteLine("hello");
    }
    string s = File.ReadAllText(file); //执行这一行时，文件还被占用中，会出错
    Console.WriteLine(s);
}


