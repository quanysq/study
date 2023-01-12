using Microsoft.AspNetCore.Identity;

// IdentityUser<long> 表示 long 类型主键的用户实体类
// IdentityUser中定义了UserName（用户名）、Email（邮箱）、PhoneNumber（手机号）、PasswordHash（密码的哈希值）等属性，
// 这里又添加了CreationTime（创建时间）、NickName（昵称）两个属性。
public class User: IdentityUser<long>
{
	public DateTime CreationTime { get; set; }
	public string? NickName { get; set; }
}
