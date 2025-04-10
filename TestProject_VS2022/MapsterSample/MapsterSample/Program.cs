using Mapster;
using MapsterSample.Dtos;
using MapsterSample.Entities;
using MapsterSample;

// 配置 Mapster 映射规则
// 在默认情况下，Mapster 会根据两个实体字段名称相同进行匹配。
// 所以如果有两个类，它们的字段名称一致，那么 Mapster 将会自动将一个类的属性值映射到另一个类的相应属性上。
// 当需要更复杂的对象映射时，需要通过 `TypeAdapterConfig` 进行配置。
// 例如，你可以定义自定义的映射规则，指定如何从源对象映射到目标对象。这种方式允许你灵活地控制映射过程中的细节。
TypeAdapterConfig<Person, PersonDto>
    .NewConfig()
    .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
    .Map(dest => dest.Age, src => CommonUtil.CalculateAge(src.DateOfBirth))
    .AfterMapping((src, dest) =>
    {
        // 自定义逻辑，例如添加额外的信息
        dest.CreatedAt = DateTime.Now;
    });

// 创建一个 Person 实体对象
var person = new Person
{
    Id = 1,
    FirstName = "Jacky",
    LastName = "Yang",
    DateOfBirth = new DateTime(1990, 1, 1)
};

// 使用 Mapster 将 person 对象映射为 PersonDto 类型
var personDto = person.Adapt<PersonDto>();

// 输出映射结果
Console.WriteLine($"Full Name: {personDto.FullName}");
Console.WriteLine($"Age: {personDto.Age}");
Console.WriteLine($"Created At: {personDto.CreatedAt}");

Console.ReadKey();

