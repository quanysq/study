using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingDemo
{
    public abstract class MyMessage
    {
    }

    // 定义文本消息类
    public class TextMessage : MyMessage
    {
        public string Content { get; set; }
        public TextMessage(string content) => Content = content;
    }

    // 定义电子邮件消息类
    public class EmailMessage : MyMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public EmailMessage(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }

    // 定义警告消息类
    public class AlertMessage : MyMessage
    {
        public string Message { get; set; }
        public AlertMessage(string message) => Message = message;
    }
}
