using Application.Features.Inventory.Commands.Request;
using Application.Features.Inventory.Dtos;
using AutoMapper;
using Domain.Aggregate;
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
    public class InventoryMappingProfile : Profile
    {
        public InventoryMappingProfile()
        {
            CreateMap<NewInventoryCommandRequest, InventoryDto>().ReverseMap();
            CreateMap<Inventory, InventoryDto>().ReverseMap();
        }
    }
}
