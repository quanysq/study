using Microsoft.Extensions.DependencyInjection;
using 例子服务接口1;
using Zack.Commons;

// 1.创建服务注册容器
ServiceCollection services=new ServiceCollection();

// 2.调用GetAllReferencedAssemblies方法获取所有的用户程序集
var assemblies = ReflectionHelper.GetAllReferencedAssemblies();

// 3.调用RunModuleInitializers方法扫描指定程序集中所有实现了IModuleInitializer接口的类
//   并且调用它们的Initialize方法来完成服务的注册
services.RunModuleInitializers(assemblies);

// 4.使用
using var sp = services.BuildServiceProvider();

var items = sp.GetServices<IMyService>();
foreach (var item in items)
{
    item?.SayHello();
}


