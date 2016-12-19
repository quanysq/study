using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console004
{
  /// <summary>
  /// ThreadPool.QueueUserWorkItem - 限定多线程的线程数量 1
  /// </summary>
  public class C10
  {
    public static void Execute()
    {
      var rnd = new Random();
      var lst = new MyTaskList();
      for (var i = 0; i < 100; i++)
      {
        var s = rnd.Next(10);
        var j = i;
        var testTask = new Action(() =>
        {
          Console.WriteLine(string.Format("第{0}个任务（用时{1}秒）已经开始", j, s));
          Thread.Sleep(s * 1000);
          Console.WriteLine(string.Format("第{0}个任务（用时{1}秒）已经结束", j, s));
        });
        lst.Tasks.Add(testTask);
      }
      lst.Completed += () => Console.WriteLine("____________________没有更多的任务了！");
      lst.Start();
    }
  }

  public class MyTaskList
  {
    public List<Action> Tasks = new List<Action>();

    public void Start()
    {
      for (var i = 0; i < 5; i++)
        StartAsync();
    }

    public event Action Completed;

    public void StartAsync()
    {
      lock (Tasks)
      {
        if (Tasks.Count > 0)
        {
          var t = Tasks[Tasks.Count - 1];
          Tasks.Remove(t);
          ThreadPool.QueueUserWorkItem(h =>
          {
            t();
            StartAsync();
          });
        }
        else if (Completed != null)
          Completed();
      }
    }
  }
}
