using Autofac;
using Autofac.Integration.WebApi;
using AutofacSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AutofacSample.App_Start
{
    /// <summary>
    /// Autofac 配置类
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 依赖注入配置
        /// </summary>
        public static void RegisterConfig()
        {
            // 创建一个容器
            var builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;

            // 注册业务服务，即接口
            // 注册时，可以选择三种生命周期
            // InstancePerDependency：每次请求都会创建新的实例，这是默认的生命周期
            // SingleInstance：单例模式，整个应用程序生命周期内只创建一个实例
            // InstancePerLifetimeScope：在一个生命周期范围内创建一个实例，这个范围可以是容器、子容器或者命名的子容器
            // InstancePerMatchingLifetimeScope：在匹配的生命周期范围内创建实例，必须是父子容器或命名容器之间的匹配
            // InstancePerHttpRequest：在一个HTTP请求内创建一个实例，仅适用于ASP.NET环境
            builder.RegisterType<GreeterImpl>().As<IGreeter>().InstancePerDependency();
            
            // 上面为了演示，手动注册一个服务，实际开发时，可以使用反射将要注册的服务统一注册，代码逻辑更加简洁，如下
            // builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            // 注册 API 控制器
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            // 设置 Web API 的解析器
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}