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
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();
        }
    }
}