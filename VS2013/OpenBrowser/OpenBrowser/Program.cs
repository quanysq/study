using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;
using System.IO;

namespace OpenBrowser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 运行前先确保浏览器已经关闭
            Console.Write("浏览器都已经关闭了吗？(y / n)：");
            var answer = Console.ReadLine();
            if (answer != "y") return;

            var edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            var chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            OpenBrowser(edgePath, "edge");
            Thread.Sleep(3000);
            OpenBrowser(chromePath, "chrome");
        }

        private static void OpenBrowser(string browserPath, string browserType)
        {
            

            // 启动 Edge 浏览器
            var historyNum = GetBrowserHistoryNum(browserType);
            Console.WriteLine($"{browserType} 浏览器要打开的最近关闭的历史记录的数量是 [{historyNum}]");

            using (Process browserProcess = new Process())
            {
                Console.WriteLine($"准备启动 {browserType} 浏览器......");
                browserProcess.StartInfo.FileName = browserPath;
                browserProcess.Start();

                Console.WriteLine($"等待 {browserType} 浏览器启动完成......");
                browserProcess.WaitForInputIdle();

                // 等待 1 秒确定浏览器完全打开
                Thread.Sleep(1000);

                InputSimulator simulator = new InputSimulator();
                for (var i = 1; i <= historyNum; i++)
                {
                    List<VirtualKeyCode> modifierKeycodes = new List<VirtualKeyCode>();
                    modifierKeycodes.Add(VirtualKeyCode.CONTROL);
                    modifierKeycodes.Add(VirtualKeyCode.SHIFT);
                    simulator.Keyboard.ModifiedKeyStroke(modifierKeycodes, VirtualKeyCode.VK_T);
                    Console.WriteLine($"打开第 {i} 个最近关闭的历史记录");
                }
            }
        }

        private static int GetBrowserHistoryNum(string browserName)
        {
            int historyNum = 0;
            string filePath = browserName == "edge" ? "./EdgeHisNum.txt" : "ChromeHisNum.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                historyNum = int.Parse(sr.ReadToEnd());
            }

            return historyNum;
        }
    }
}
