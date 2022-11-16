using static System.Linq.Expressions.Expression;
using System.Linq.Expressions;
using ExpressionTreeToString;
using System.Reflection;
using System.Linq.Dynamic.Core;

using var ctx = new TestDbContext();

//Func<Book, bool> f1 = b => b.Price > 5 || b.AuthorName.Contains("杨中科");
//Expression<Func<Book, bool>> e = b => b.Price > 5 || b.AuthorName.Contains("杨中科");
//Console.WriteLine(f1);
//Console.WriteLine(e);

//ExpressionTreeToString的基本使用
//Expression<Func<Book, bool>> e = b => b.AuthorName.Contains("杨中科") || b.Price > 30;
//Console.WriteLine(e.ToString("Object notation", "C#"));

//动态创建和Expression<Func<Book, bool>> e = b =>b.Price > 5一样的代码
/*
// 使用Parameter方法创建了b这个参数节点
ParameterExpression paramB = Expression.Parameter(typeof(Book), "b");
// 使用MakeMemberAccess方法创建了访问b的Price属性操作的节点
MemberExpression exprLeft = Expression.MakeMemberAccess(paramB, typeof(Book).GetProperty("Price"));
// 使用Constant创建对应5这个常量的节点
ConstantExpression exprRight = Expression.Constant(5.0, typeof(double));
// 使用MakeBinary方法创建了对应“大于”符号的二元运算符节点，并且把exprLeft和exprRight分别设置为“大于”节点的左节点和右节点
BinaryExpression exprBody = Expression.MakeBinary(ExpressionType.GreaterThan, exprLeft, exprRight);
// 使用Lambda方法把exprBody放到一个表达式树节点中，
// Lambda方法主要用来设定表达式的参数和返回值类型
Expression<Func<Book, bool>> expr1 = Expression.Lambda<Func<Book, bool>>(exprBody, paramB);
// 使用动态生成的表达式树查询数据
ctx.Books.Where(expr1).ToList();
Console.WriteLine(expr1.ToString("Object notation", "C#"));
*/

//ExpressionTreeToString的Factory methods
//Expression<Func<Book, bool>> e = b => b.AuthorName.Contains("杨中科") || b.Price > 30;
//Console.WriteLine(e.ToString("Factory methods", "C#"));

//动态构建表达式书的代码
//var b = Parameter(typeof(Book), "b");
//var expr1 = Lambda<Func<Book, bool>>(OrElse(
//        Call(MakeMemberAccess(b, typeof(Book).GetProperty("AuthorName")),
//             typeof(string).GetMethod("Contains", new[] { typeof(string) }),
//             Constant("杨中科")),
//        GreaterThan(MakeMemberAccess(b, typeof(Book).GetProperty("Price")),
//             Constant(30.0))
//    ), b );
//ctx.Books.Where(expr1).ToList();
//Console.WriteLine(expr1.ToString("Object notation", "C#"));

//不同类型的相等比较
//Expression<Func<Book, bool>> expr1 = b => b.Price == 5;
//Expression<Func<Book, bool>> expr2 = b => b.Title == "零基础趣学C语言";
//Console.WriteLine(expr1.ToString("Factory methods", "C#"));
//Console.WriteLine(expr2.ToString("Factory methods", "C#"));

//5.3.7 让构建“动态”起来
//QueryBooks("Price", 18.0);
//QueryBooks("AuthorName", "杨中科");
//QueryBooks("Title", "零基础趣学C语言");
//static IEnumerable<Book> QueryBooks(string propName, object value)
//{
//	Type type = typeof(Book);
//	PropertyInfo propInfo = type.GetProperty(propName);
//	Type propType = propInfo.PropertyType;
//	var b = Parameter(typeof(Book), "b");
//	Expression<Func<Book, bool>> expr;
//	if (propType.IsPrimitive)//如果是int、double等基本数据类型
//	{
//		expr = Lambda<Func<Book, bool>>(Equal(
//				MakeMemberAccess(b, typeof(Book).GetProperty(propName)),
//				Constant(value)), b);
//	}
//	else//如果是string等类型
//	{
//		expr = Lambda<Func<Book, bool>>(MakeBinary(ExpressionType.Equal,
//				MakeMemberAccess(b, typeof(Book).GetProperty(propName)),
//				Constant(value), false, propType.GetMethod("op_Equality")
//			), b);
//	}
//	TestDbContext ctx = new TestDbContext();
//	return ctx.Books.Where(expr).ToArray();
//}

//5.3.8	不用Emit生成IL代码实现Select的动态化
//var items = Query<Book>(new string[] { "Id", "PubTime", "Title" });
//foreach (object[] row in items)
//{
//	long id = (long)row[0];
//	DateTime pubTime = (DateTime)row[1];
//	string title = (string)row[2];
//	Console.WriteLine(id + "," + pubTime + "," + title);
//}
//IEnumerable<object[]> Query<TEntity>(string[] propNames) where TEntity : class
//{
//	ParameterExpression exParameter = Expression.Parameter(typeof(TEntity));
//	List<Expression> exProps = new List<Expression>();
//	foreach (string propName in propNames)
//	{
//		Expression exProp = Expression.Convert(Expression.MakeMemberAccess(
//			exParameter, typeof(TEntity).GetProperty(propName)), typeof(object));
//		exProps.Add(exProp);
//	}
//	Expression[] initializers = exProps.ToArray();
//	NewArrayExpression newArrayExp = Expression.NewArrayInit(typeof(object), initializers);
//	var selectExpression = Expression.Lambda<Func<TEntity, object[]>>(newArrayExp, exParameter);
//	using TestDbContext ctx = new TestDbContext();
//	IQueryable<object[]> selectQueryable = ctx.Set<TEntity>().Select(selectExpression);
//	return selectQueryable.ToArray();
//}

//使用 System.Linq.Dynamic.Core 动态构建
string word = "C语言";
var books = ctx.Books.WhereInterpolated($"Price>8 or Title.Contains({word})");
foreach (var b in books)
{
    Console.WriteLine($"{b.Id},{b.Title},{b.Price}");
}
