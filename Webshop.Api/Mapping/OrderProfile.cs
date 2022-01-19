using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApp.Models.ModelDTO;
using WebShopApp.Models;
using WebShopApp.Models.ModelsDTO;

namespace WebShopApp.Mapping
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
