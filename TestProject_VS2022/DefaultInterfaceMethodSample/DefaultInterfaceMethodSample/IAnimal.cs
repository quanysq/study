using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultInterfaceMethodSample
{
    public interface IAnimal
    {
        void Eat();

        // 默认方法
        void Speak()
        {
            Console.WriteLine("这个动物发出声音");
        }
    }
}
