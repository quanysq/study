using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp;
using PostSharp.Aspects;

namespace Console018
{
  /// <summary>
  /// 面向切面编号（AOP）[PostSharp]
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //C1.ExceptionAspectDemoAttribute1();    
      //C1.ExceptionAspectDemoAttribute2();

      //C2.OnMethodBoundaryAspectDemoAttributeTest();

      //C3 c3 = new C3();
      //c3.Execute();

      //C4.Execute();

      //C5.Execute();

      C6.Execute();

      Console.Read();
    }
    
  }

  /*
   * 切面（Aspect）：其实就是共有功能的实现。如日志切面、权限切面、事务切面等。在实际应用中通常是一个存放共有功能实现的普通Java类，
   * 之所以能被AOP容器识别成切面，是在配置中指定的。
   * 
   * 通知（Advice）：是切面的具体实现。以目标方法为参照点，根据放置的地方不同，可分为前置通知（Before）、后置通知（AfterReturning）、
   * 异常通知（AfterThrowing）、最终通知（After）与环绕通知（Around）5种。在实际应用中通常是切面类中的一个方法，具体属于哪类通知，
   * 同样是在配置中指定的。
   * 
   * 连接点（Joinpoint）：就是程序在运行过程中能够插入切面的地点。例如，方法调用、异常抛出或字段修改等，但Spring只支持方法级的连接点。
   * 
   * 切入点（Pointcut）：用于定义通知应该切入到哪些连接点上。不同的通知通常需要切入到不同的连接点上，这种精准的匹配是由切入点的正则表达式来定义的。
   * 
   * 目标对象（Target）：就是那些即将切入切面的对象，也就是那些被通知的对象。这些对象中已经只剩下干干净净的核心业务逻辑代码了，
   * 所有的共有功能代码等待AOP容器的切入。
   * 
   * 代理对象（Proxy）：将通知应用到目标对象之后被动态创建的对象。可以简单地理解为，代理对象的功能等于目标对象的核心业务逻辑功能加上
   * 共有功能。代理对象对于使用者而言是透明的，是程序运行过程中的产物。
   * 
   * 织入（Weaving）：将切面应用到目标对象从而创建一个新的代理对象的过程。这个过程可以发生在编译期、类装载期及运行期，当然不同的发生点
   * 有着不同的前提条件。譬如发生在编译期的话，就要求有一个支持这种AOP实现的特殊编译器；发生在类装载期，就要求有一个支持AOP实现的特殊
   * 类装载器；只有发生在运行期，则可直接通过Java语言的反射机制与动态代理机制来动态实现。
   */

}
