using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console033
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory());

      ConsoleUtil.Write("错误", ConsoleColor.Red, ConsoleColor.Black);
      ConsoleUtil.Write("成功", ConsoleColor.DarkGreen, ConsoleColor.Black);
      ConsoleUtil.Write("警告", ConsoleColor.Yellow, ConsoleColor.Black);
      
      Console.WriteLine("测试");
    }
  }

  class ConsoleUtil
  {
    public static void Write(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
    {
      Console.ForegroundColor = foregroundColor;
      Console.BackgroundColor = backgroundColor;
      Console.Write(text);
      Console.WriteLine();
      Console.ResetColor();
    }

    public static void Error(Exception ex)
    {
      Console.WriteLine();
      ConsoleUtil.Write("Error", ConsoleColor.Red, ConsoleColor.Black);
      Console.Write(" : ");
      Console.WriteLine(ex.Message);
      Console.WriteLine(ex.StackTrace);
    }

    public static void Warn(Exception ex)
    {
      Console.WriteLine();
      ConsoleUtil.Write("Warn", ConsoleColor.Yellow, ConsoleColor.Black);
      Console.Write(" : ");
      Console.WriteLine(ex.Message);
      Console.WriteLine(ex.StackTrace);
    }
  }
}
