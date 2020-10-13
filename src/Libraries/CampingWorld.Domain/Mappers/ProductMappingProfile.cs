using System;
using System.Collections.Generic;
using System.Text;
using CampingWorld.Domain.Models;
using Grpc.Net.Client;
using Proto;
using AutoMapper;
using System.Linq;

namespace CampingWorld.Domain.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
             CreateMap<Product, ProductReply>()
             .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
             .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
             .ForMember(dest => dest.Cost, source => source.MapFrom(src => src.Cost.ToString()))
             .ForMember(dest => dest.Price, source => source.MapFrom(src => src.Price.ToString()));

             CreateMap<Product, ProductRequest>()
             .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
             .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
             .ForMember(dest => dest.Cost, source => source.MapFrom(src => src.Cost.ToString()))
             .ForMember(dest => dest.Price, source => source.MapFrom(src => src.Price.ToString()));

             CreateMap<IEnumerable<Product>, ProductsReply>()
             .ForMember(dest => dest.Products, source => source.MapFrom(src => src));

             CreateMap<ProductReply, Product>()
             .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
             .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
             .ForMember(dest => dest.Cost, source => source.MapFrom(src => System.Convert.ToDecimal(src.Cost)))
             .ForMember(dest => dest.Price, source => source.MapFrom(src => System.Convert.ToDecimal(src.Price)));

             CreateMap<ProductRequest, Product>()
             .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
             .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
             .ForMember(dest => dest.Cost, source => source.MapFrom(src => System.Convert.ToDecimal(src.Cost)))
             .ForMember(dest => dest.Price, source => source.MapFrom(src => System.Convert.ToDecimal(src.Price)));
        }
    }
}
