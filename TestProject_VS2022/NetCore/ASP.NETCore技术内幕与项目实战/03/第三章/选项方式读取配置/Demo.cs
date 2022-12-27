using Microsoft.Extensions.Options;

class Demo
{
    // IOptionsSnapshot<T>在配置改变后，能读到新的值
    private readonly IOptionsSnapshot<DbSettings> optDbSettings;
    private readonly IOptionsSnapshot<SmtpSettings> optSmtpSettings;

    // 构造方法注入 IOptionsSnapshot
    public Demo(
        IOptionsSnapshot<DbSettings> optDbSettings,
        IOptionsSnapshot<SmtpSettings> optSmtpSettings
        )
    {
        this.optDbSettings = optDbSettings;
        this.optSmtpSettings = optSmtpSettings;
    }

    public void Test()
    {
        var db = optDbSettings.Value;
        Console.WriteLine($"数据库：{db.DbType},{db.ConnectionString}");
        var smtp = optSmtpSettings.Value;
        Console.WriteLine($"Smtp：{smtp.Server},{smtp.UserName},{smtp.Password}");
    }
}
