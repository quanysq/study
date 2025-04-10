//using System;
//using GeneratedClasses;

//// 测试 Person 类
//Person person = new Person
//{
//    FirstName = "John",
//    LastName = "Doe",
//    Age = 30
//};
//Console.WriteLine($"Person: {person.FirstName} {person.LastName}, Age: {person.Age}");

//// 测试 Car 类
//Car car = new Car
//{
//    Make = "Toyota",
//    Model = "Camry",
//    Year = 2021
//};
//Console.WriteLine($"Car: {car.Make} {car.Model}, Year: {car.Year}");

// using SourceGeneratorSample;

var person = new Person { Name = "Alice", Age = 30 };
Console.WriteLine(person.ToString()); // 输出：Person {Name = Alice, Age = 30}