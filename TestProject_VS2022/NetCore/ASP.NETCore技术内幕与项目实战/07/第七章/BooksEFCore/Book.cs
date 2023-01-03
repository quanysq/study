// 把Book类声明为一个记录类，而不是普通的类，主要是为了让编译器自动生成ToString方法，简化对象的输出
public record Book
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public double Price { get; set; }
}