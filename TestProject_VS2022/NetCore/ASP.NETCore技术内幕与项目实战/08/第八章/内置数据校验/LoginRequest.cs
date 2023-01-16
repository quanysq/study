using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
    // 直接对类属性设置数据内置检验
    [Required]
    [EmailAddress]
    [RegularExpression("^.*@(qq|163)\\.com$", ErrorMessage = "只支持QQ和163邮箱")]
    public string Email { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 3)]
    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "两次密码必须一致")]
    public string PasswordConfirm { get; set; }
}
