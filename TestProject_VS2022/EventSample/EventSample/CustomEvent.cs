using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample
{
    // 定义一个自定义事件参数类
    public class CustomEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    // 定义一个类，包含事件
    public class EventPublisher
    {
        // 声明一个事件，使用自定义的委托类型
        public event EventHandler<CustomEventArgs> CustomEvent;

        // 触发事件的方法
        public void TriggerEvent()
        {
            // 触发事件时传递自定义参数
            CustomEvent?.Invoke(this, new CustomEventArgs { Message = "事件被触发！" });
        }
    }

    // 定义一个订阅者类
    public class EventSubscriber
    {
        // 事件处理方法
        public void HandleEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"接收到事件消息：{e.Message}");
        }
    }
}
