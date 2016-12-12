using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Console000
{
  /// <summary>
  /// Unity
  /// </summary>
  class Class6
  {
    public static void Execute(string[] args)
    {
      //ContainerCode();
      ContainerConfiguration2();
    }

    /// <summary>
    /// 代码注入
    /// </summary>
    static void ContainerCode()
    {
      IUnityContainer container = new UnityContainer();
      container.RegisterType<IProduct, Milk>();                             //默认注册（无命名）,如果后面还有默认注册会覆盖前面的
      container.RegisterType<IProduct, Sugar>("Sugar");                     //命名注册

      IProduct _product = container.Resolve<IProduct>();                    //解析默认对象
      _product.ClassName = _product.GetType().ToString();
      _product.ShowInfo();
      IProduct _sugar = container.Resolve<IProduct>("Sugar");               //指定命名解析对象
      _sugar.ClassName = _sugar.GetType().ToString();
      _sugar.ShowInfo();
      IEnumerable<IProduct> classList = container.ResolveAll<IProduct>();   //获取容器中所有IProduct的注册的已命名对象
      foreach (var item in classList)
      {
        item.ClassName = item.GetType().ToString();
        item.ShowInfo();
      }
    }

    /// <summary>
    /// 配置文件注入(读取App.config)
    /// </summary>
    static void ContainerConfiguration1()
    {

      IUnityContainer container = new UnityContainer();
      container.LoadConfiguration("MyContainer");
      //获取指定名称的配置节
      UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");   
      //获取特定配置节下已命名的配置节<container name='MyContainer'>下的配置信息
      section.Configure(container, "MyContainer");
      IProduct classInfo = container.Resolve<IProduct>("Sugar");
      classInfo.ShowInfo();
    }

    /// <summary>
    /// 配置文件注入(读取自定义的Config文件-Unity.config)
    /// </summary>
    static void ContainerConfiguration2()
    {
      IUnityContainer container = new UnityContainer();
      string configFile = "Unity.config";
      var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
      //从config文件中读取息
      Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
      //获取指定名称的配置节
      UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");
      //载入名称为FirstClass 的container节点
      container.LoadConfiguration(section, "MyContainer");
      IProduct classInfo = container.Resolve<IProduct>();
      classInfo.ShowInfo();
    }
  }

  /// <summary>
  /// 商品
  /// </summary>
  interface IProduct
  {
    string ClassName { get; set; }
    void ShowInfo();
  }

  /// <summary>
  /// 牛奶
  /// </summary>
  class Milk : IProduct
  {
    public string ClassName { get; set; }
    public void ShowInfo()
    {
      Console.WriteLine("牛奶：{0}", ClassName);
    }
  }

  /// <summary>
  /// 糖
  /// </summary>
  public class Sugar : IProduct
  {
    public string ClassName { get; set; }
    public void ShowInfo()
    {
      Console.WriteLine("糖：{0}", ClassName);
    }
  }

  /*
   * （1）用编程方式实现注入
      使用Unity来管理对象与对象之间的关系可以分为以下几步：
      A、创建一个UnityContainer对象
      B、通过UnityContainer对象的RegisterType方法来注册对象与对象之间的关系
      C、通过UnityContainer对象的Resolve方法来获取指定对象关联的对象
   * 
   * （2）配置文件方式
      通过配置文件配置Unity信息需要有以下几个步骤：
      A、在配置文件<configSections> 配置节下注册名为unity的section
      B、在<configuration> 配置节下添加Unity配置信息
      C、在代码中读取配置信息，并将配置载入到UnityContainer中
   */
}
