using AutoMapper;
using AutoMapperSample.Dtos;
using AutoMapperSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperSample
{
    public class PersonService
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// 在构造方法中注入 IMapper
        /// </summary>
        /// <param name="mapper"></param>
        public PersonService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void DoMapping()
        {
            // 假设从数据库查询到用户实体
            var personEntity = new Person
            {
                Id = 1,
                FirstName = "Jacky",
                LastName = "Yang",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            // 使用 AutoMapper 进行转换，将 personEntity 对象映射为 PersonDto 类型
            var personDto = _mapper.Map<PersonDto>(personEntity);

            Console.WriteLine($"Full Name: {personDto.FullName}");
            Console.WriteLine($"Age: {personDto.Age}");
        }
    }
}
