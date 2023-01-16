using FluentValidation;

// 数据校验类要继承自AbstractValidator
// 通过AbstractValidator的泛型参数指定对哪个类进行校验
public class LoginRequestValidator: AbstractValidator<LoginRequest>
{
    // 校验规则写到校验类的构造方法中
    public LoginRequestValidator()
    {
        // 通过RuleFor来指定要对哪个属性进行校验
        // 多个校验规则可以采用链式调用的写法
        // 每个需要校验的属性对应一组RuleFor调用
        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress()
            // 在Must方法中编写自定义校验规则，
            .Must(v => v.EndsWith("@qq.com") || v.EndsWith("@163.com"))
            // 通过WithMessage方法自定义报错信息，
            // WithMessage方法设置的报错信息只作用于它之前的那个校验规则
            .WithMessage("只支持QQ和163邮箱");

        RuleFor(x => x.Password)
            .NotNull()
            .Length(3, 10).WithMessage("密码长度必须介于3到10之间")
            .Equal(x => x.PasswordConfirm).WithMessage("两次密码必须一致");
    }
}
