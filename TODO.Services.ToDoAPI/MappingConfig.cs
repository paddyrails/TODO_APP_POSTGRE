using System;
using AutoMapper;
using TODO.Services.ToDoAPI.Models;
using TODO.Services.ToDoAPI.Models.Dto;

namespace TODO.Services.ToDoAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ToDoDto, ToDo>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}