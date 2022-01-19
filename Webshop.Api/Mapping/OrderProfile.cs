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
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderCreateDTO, Product>();
            CreateMap<OrderUpdateDTO, Product>();
        }
    }
}
