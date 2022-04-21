using Autofac;
using Autofac.Integration.Mvc;
using MVCExample.BLL.IService;
using MVCExample.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Dependency
{
    public class AutofacConfig
    {
        /// <summary>
        /// 依赖注入配置
        /// </summary>
        public static void RegisterConfig()
        {
            // 创建一个容器
            var builder = new ContainerBuilder();


            //注入业务层 
            //实践中，以下这两项似乎不注入也是可以的
            builder.RegisterType<AdminUserService>().As<IAdminUserService>().InstancePerDependency();
            builder.RegisterType<HTFP14Service>().As<IHTFP14Service>().InstancePerDependency();
            //builder.RegisterType<ModuleService>().As<IModuleService>().InstancePerDependency();


            builder.RegisterControllers(Assembly.GetExecutingAssembly());//控制器注入
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}