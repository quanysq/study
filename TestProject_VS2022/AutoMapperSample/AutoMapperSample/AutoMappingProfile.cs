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
    /// <summary>
    /// 配置映射规则
    /// </summary>
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // 配置源类型和目标类型
            CreateMap<Person, PersonDto>()
                // 自定义转换规则
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => CalculateAge(src.DateOfBirth)));
        }

        /// <summary>
        /// 根据出生日期计算年龄
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        private int CalculateAge(DateTime dateOfBirth)
        {
            return (DateTime.Today.Year - dateOfBirth.Year) - ((DateTime.Today.Month < dateOfBirth.Month) ? 1 : 0);
        }
    }
}
