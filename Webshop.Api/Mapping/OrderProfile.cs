using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Api.Models.ModelDTO;
using Webshop.Api.Models;
using Webshop.Api.Models.ModelsDTO;

namespace Webshop.Api.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            
            CreateMap<OrderDetailsDto, OrderDetails>()
                .ReverseMap().DisableCtorValidation();
            CreateMap<OrderDetailsCreateDto, OrderDetailsDto>().ReverseMap();
            CreateMap<OrderDetailsCreateDto, OrderDetails>().ReverseMap();
            CreateMap<OrderCreateDTO, Order>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderCreateDTO, OrderDTO>().ReverseMap();
            CreateMap<OrderUpdateDTO, Order>().ReverseMap();

        }
    }
}
