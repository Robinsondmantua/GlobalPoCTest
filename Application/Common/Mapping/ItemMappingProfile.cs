using Application.Features.Item.Commands.Request;
using Application.Features.Item.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    /// <summary>
    /// This class is used for profiling the mapping configuration 
    /// </summary>
    public class ItemMapProfile : Profile
    {
        public ItemMapProfile()
        {
            CreateMap<NewItemCommandRequest, ItemDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
        }
    }
}
