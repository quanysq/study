using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSample.Services
{
    /// <summary>
    /// 创建一个简单的服务接口
    /// </summary>
    public interface IGreeter
    {
        string Greet(string name);
    }
}
