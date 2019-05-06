using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AutoMapper;
using AutoMapper;
namespace WebHostConfiguration
{
    public class MapperProfileEx: Profile
    {
        protected  void Configure()
        {

            //映射，需要将出生日期映射到DTO中为年、月
            //CreateMap()
            //    .ForMember(dto => dto.Birth_Month, opt => opt.MapFrom(src => src.Birth.Month))
            //    .ForMember(dto => dto.Birth_Year, opt => opt.MapFrom(src => src.Birth.Year));
        }

    }
  
}
