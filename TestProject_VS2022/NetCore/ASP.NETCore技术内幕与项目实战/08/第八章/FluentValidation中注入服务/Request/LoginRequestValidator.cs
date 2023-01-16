using FluentValidation;
using Microsoft.EntityFrameworkCore;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    // 通过构造方法注入了TestDbContext
    public LoginRequestValidator(TestDbContext dbCtx)
    {
        RuleFor(x => x.UserName)
            .NotNull()
            // 使用TestDbContext服务检查用户名是否存在
            // 同步方式
            .Must(name => dbCtx.Users.Any(u => u.UserName == name))
            // 异步方式，但使用异步后出错，暂时未能找到解决方案
            //.MustAsync((name,_) => dbCtx.Users.AnyAsync(u => u.UserName == name))
            // 用Lambda表达式的形式使用模型类中的属性对报错信息进行格式化
            .WithMessage(c => $"用户名{c.UserName}不存在");
    }
}
