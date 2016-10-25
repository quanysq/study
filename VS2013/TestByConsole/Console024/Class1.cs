using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 单例模式(Singleton Pattern)
  /// </summary>
  public class C1
  {
    public static void Execute()
    {
      SingleThread_Singleton.Instance.ShowMsg();

      Console.ReadKey();
    }
  }

  /// <summary>
  /// 单线程
  /// </summary>
  class SingleThread_Singleton
  {
    private static SingleThread_Singleton instance = null;
    private SingleThread_Singleton() { }
    public static SingleThread_Singleton Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new SingleThread_Singleton();
        }
        return instance;
      }
    }

    public void ShowMsg()
    {
      Console.WriteLine("这是单例模式");
    }
  }

  /// <summary>
  /// 多线程
  /// </summary>
  class MultiThread_Singleton
  {
    private static volatile MultiThread_Singleton instance = null;  //关键字volatile 保证严格意义的多线程编译器在代码编译时对指令不进行微调
    private static object lockHelper = new object();
    private MultiThread_Singleton() { }
    public static MultiThread_Singleton Instance
    {
      get
      {
        if (instance == null)
        {
          lock (lockHelper)
          {
            if (instance == null)
            {
              instance = new MultiThread_Singleton();
            }
          }
        }
        return instance;
      }
    }
  }

  /*
   * 适用性：
    （1）当类只能有一个实例而且客户可以从一个众所周知的访问点访问它时。
    （2）当这个唯一实例应该是通过子类化可扩展的，并且客户应该无需更改代码就能使用一个扩展的实例时。
   */
}
