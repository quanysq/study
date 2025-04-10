using DefaultInterfaceMethodSample;

IAnimal dog = new Dog();
dog.Eat();      // 输出: 狗吃牛肉
dog.Speak();    // 输出: 这个动物发出声音。

Console.WriteLine();

IAnimal cat = new Cat();
cat.Eat();      // 输出: 猫吃鱼
cat.Speak();    // 输出: 喵喵~