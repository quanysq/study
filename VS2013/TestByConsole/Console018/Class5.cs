using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace Console018
{
  public class C5
  {
    public static void Execute()
    {
      Student_C5 stu = new Student_C5();
      stu.ID = 10;
      Console.WriteLine(stu.Name);
      Console.WriteLine(stu.Name);

      Console.WriteLine(Student_C5.TestStaticProperty);
      Console.WriteLine(Student_C5.TestStaticProperty);
      Console.Read(); 
    }

    public static string TextLazyLoadStaticMenthod(Student_C5 stu)
    {
      return "Student" + stu.ID + "1122";
    }

    public string TextLazyLoadInstacnceMenthod(Student_C5 stu)
    {
      return "Student" + stu.ID;
    }

    public string TextLazyLoadStaticPropertyMenthod()
    {
      return "测试";
    }

  }
  
  [Serializable]
  public class LazyLoadAttribute : LocationInterceptionAspect
  {
    public string MethodName
    {
      get;
      private set;
    }

    public string PrivoderFullName
    {
      get;
      private set;
    }

    public LazyLoadAttribute(string MethodName, string PrivoderFullName)
    {
      
      Guard.ArgumentNotNullOrEmpty(MethodName, "MethodName");
      Guard.ArgumentNotNullOrEmpty(PrivoderFullName, "PrivoderFullName");
      this.MethodName = MethodName;
      this.PrivoderFullName = PrivoderFullName;
    }

    public override void OnGetValue(LocationInterceptionArgs args)
    {
      if (args.GetCurrentValue() == null)
      {
        Console.WriteLine("Loading....");
        var value = this.LoadProperty(args.Instance);
        if (value != null)
        {
          args.Value = value;
          args.ProceedSetValue();
        }
      }
      args.ProceedGetValue();
    }

    private object LoadProperty(object p)
    {
      var type = Type.GetType(this.PrivoderFullName);//具体加载程序集需要自定义需求，这里仅为了测试简化。 
      if (type != null)
      {
        var method = type.GetMethod(this.MethodName);
        if (method != null)
        {
          object[] ps = null;
          if (p != null)
          {
            ps = new object[] { p };
          }
          object entity = null;
          if (!method.IsStatic)
          {
            entity = System.Activator.CreateInstance(type);
          }
          return method.Invoke(entity, ps);
        }
      }
      return null;
    }
  }

  public class Student_C5
  {
    [LazyLoad("TextLazyLoadStaticMenthod", "Console018.C5,Console018")] 
    //[LazyLoad("TextLazyLoadInstacnceMenthod", "Console018.C5,Console018")]
    public string Name
    { get; set; }
    public string Sex
    { get; set; }

    [LazyLoad("TextLazyLoadStaticPropertyMenthod", "Console018.C5,Console018")]
    public static string TestStaticProperty
    { get; set; }

    public int ID
    { get; set; }
  }

  public static class Guard
  {
    public static void ArgumentNotNullOrEmpty(object value, string name)
    {
      if (null == value)
      {
        throw new ArgumentNullException(name);
      }
      if (value is string && string.Empty.Equals(value))
      {
        throw new ArgumentNullException(name);
      }
    }
  }

  /*
   * LocationInterceptionAspect：PostSharp官方把Property和Field成为Location。所以LocationInterceptionAspect
   * 就是为了实现Property和Field的拦截。在我们前面讨论了关于方法OnMethodBoundaryAspect的aspect，我们很容易想到，
   * c#中Property就是一个编译时分为Get和Set两个方法，对于property的aspect就类似于了我们的Method的aspect。而对于Field
   * 的aspect同样可以转换为对Property的aspect。
   * 
   * LocationInterceptionAspect的使用方法和我们的OnMethodBoundaryAspect和类似，使用方式也一样，对于使用对不重要，
   * 鄙人觉得更重要的是我们的设计思想。
   * 
   * 我暂时能想到的很好的LocationInterceptionAspect使用场景则是LazyLoad，对于3.5表达式的出现，我们到处都可以
   * 简单这个词，在c#类库中也加入了这个类。
   */
}
