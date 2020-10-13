using AutoMapper;
using CampingWorld.Domain.Models;
using Proto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampingWorld.Domain.Mappers
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerReply>()
            .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID));

            CreateMap<Customer, CustomerRequest>()
            .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID));

            CreateMap<IEnumerable<Customer>, CustomersReply>()
            .ForMember(dest => dest.Customers, source => source.MapFrom(src => src));

            CreateMap<CustomerReply, Customer>()
            .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID));

            CreateMap<CustomerRequest, Customer>()
            .ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID));
        }
    }
}

