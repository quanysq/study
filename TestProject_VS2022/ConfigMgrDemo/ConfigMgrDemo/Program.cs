using ConfigMgrDemo.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMgrDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            string configfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "democfg.config");
            var result = ConfigUtil.Deserialize<CfgModel>(configfilePath);
            Console.WriteLine($"Host URL is [{result.Host.URL}]");
            Console.WriteLine($"AdminUser is [{result.AdminUser}]");
        }
    }
}
