using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultInterfaceMethodSample
{
    public class Dog : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("狗吃牛肉");
        }

        // 使用默认实现
        // public void Speak() { } // 可以选择是否重写
    }

    public class Cat : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("猫吃鱼");
        }

        public void Speak()
        {
            Console.WriteLine("喵喵~");
        }
    }
}
