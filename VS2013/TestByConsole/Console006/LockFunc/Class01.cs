using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;
using System.Threading;

namespace Console006.LockFunc
{
  /// <summary>
  /// Lock
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      LockObj1 LockObj1 = new LockObj1();
      //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
      Thread t1 = new Thread(LockObj1.LockMe);
      t1.Start(true);
      Thread.Sleep(100);
      //在主线程中lock LockObj1
      lock (LockObj1)
      {
        //调用没有被lock的方法
        LockObj1.DoNotLockMe();
        //调用被lock的方法，并试图将deadlock解除
        LockObj1.LockMe(false);
      }
      /*
       * 在t1线程中，LockMe调用了lock(this), 也就是Main函数中的LockObj1，这时候在主线程中调用lock(LockObj1)时，
       * 必须要等待t1中的lock块执行完毕之后才能访问LockObj1，即所有LockObj1相关的操作都无法完成，
       * 于是我们看到连LockObj1.DoNotLockMe()都没有执行。
       */
    }

    public static void Execute2()
    {
      LockObj2 LockObj2 = new LockObj2();
      //在t2线程中调用LockMe，并将deadlock设为true（将出现死锁）
      Thread t2 = new Thread(LockObj2.LockMe);
      t2.Start(true);
      Thread.Sleep(100);
      //在主线程中lock LockObj2
      lock (LockObj2)
      {
        //调用没有被lock的方法
        LockObj2.DoNotLockMe();
        //调用被lock的方法，并试图将deadlock解除
        LockObj2.LockMe(false);
      }
      /*
       * 这次我们使用一个私有成员作为锁定变量(locker)，在LockMe中仅仅锁定这个私有locker，
       * 而不是整个对象。这时候重新运行程序，可以看到虽然t1出现了死锁，DoNotLockMe()仍然可以由主线程访问；
       * LockMe()依然不能访问，原因是其中锁定的locker还没有被t1释放。
       */
    }
  }
  /*
   * 关键点：
   * 1. lock(this)的缺点就是在一个线程（例如本例的t1）通过执行该类的某个使用"lock(this)"的方法(例如本例的LockMe())锁定某对象之后, 
   *    导致整个对象无法被其他线程(例如本例的主线程)访问 - 因为很多人在其他线程(例如本例的主线程)中使用该类的时候会使用类似lock(c1)的代码。
   * 2. 锁定的不仅仅是lock段里的代码，锁本身也是线程安全的。
   * 3. 我们应该使用不影响其他操作的私有对象作为locker。
   * 4. 在使用lock的时候，被lock的对象(locker)一定要是引用类型的，如果是值类型，
   *    将导致每次lock的时候都会将该对象装箱为一个新的引用对象(事实上如果使用值类型，
   *    C#编译器(3.5.30729.1)在编译时就会给出一个错误)。
   */
}
