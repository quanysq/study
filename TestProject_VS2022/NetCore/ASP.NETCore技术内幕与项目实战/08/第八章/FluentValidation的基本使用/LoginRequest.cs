// LoginRequest 类只是一个普通的C#类，
// 没有标注任何的Attribute或者实现任何的接口，
// 它的唯一责任就是传递数据
public record LoginRequest(string Email, string Password, string PasswordConfirm);
