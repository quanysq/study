using System.Diagnostics;

namespace WinFormsSample
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalMutex();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // 订阅 ThreadException 事件，用于捕获 UI 线程上的未捕获异常
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // 设置未经处理的异常模式，以便在非 UI 线程上也能捕获异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // 订阅 UnhandledException 事件，用于捕获所有线程上的未捕获异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


            Application.Run(new Form1());
        }

        // 处理 UI 线程上的未捕获异常
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        // 处理所有线程上的未捕获异常
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        // 统一的异常处理方法
        private static void HandleException(Exception ex)
        {
            if (ex == null) return;

            // 记录错误日志

            // 显示友好的错误信息给用户
            MessageBox.Show(@$"
对不起，应用程序遇到了一个问题，错误信息如下：
{ex.Message}

我们已经记录了这个问题，稍后会进行修复。",
                            "应用程序错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // （可选）退出应用程序或采取其他措施
            Application.Exit();
        }

        private static Mutex mutex = null;
        private static void GlobalMutex()
        {
            bool newMutexCreated = false;
            Process current = Process.GetCurrentProcess();
            string mutexName = "Global\\" + current.ProcessName;
            try
            {
                mutex = new Mutex(false, mutexName, out newMutexCreated);
            }
            catch
            {
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
            if (!newMutexCreated)
            {
                MessageBox.Show("程序已经在运行中……","警告",MessageBoxButtons.OK);
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
        }
    }
}