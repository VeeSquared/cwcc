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
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderReply>()
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.OrderDate, source => source.MapFrom(src => src.OrderDate.ToString()))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));

            CreateMap<Order, OrderRequest>()
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.OrderDate, source => source.MapFrom(src => src.OrderDate.ToString()))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));

            CreateMap<IEnumerable<Order>, OrdersReply>()
            .ForMember(dest => dest.Orders, source => source.MapFrom(src => src));

            CreateMap<OrderReply, Order>()
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.OrderDate, source => source.MapFrom(src => Convert.ToDateTime(src.OrderDate)))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));

            CreateMap<OrderRequest, Order>()
            .ForMember(dest => dest.CustomerID, source => source.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.OrderDate, source => source.MapFrom(src => Convert.ToDateTime(src.OrderDate)))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));

            CreateMap<OrderLine, OrderLineReply>()
            .ForMember(dest => dest.OrderLineID, source => source.MapFrom(src => src.OrderLineID))
            .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
            .ForMember(dest => dest.Quantity, source => source.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));

            CreateMap<OrderLine, OrderLineRequest>()
            .ForMember(dest => dest.OrderLineID, source => source.MapFrom(src => src.OrderLineID))
            .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
            .ForMember(dest => dest.Quantity, source => source.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));

            CreateMap<IEnumerable<OrderLine>, OrderLinesReply>()
            .ForMember(dest => dest.OrderLines, source => source.MapFrom(src => src));

            CreateMap<OrderLineReply, OrderLine>()
            .ForMember(dest => dest.OrderLineID, source => source.MapFrom(src => src.OrderLineID))
            .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
            .ForMember(dest => dest.Quantity, source => source.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));

            CreateMap<OrderLineRequest, OrderLine>()
            .ForMember(dest => dest.OrderLineID, source => source.MapFrom(src => src.OrderLineID))
            .ForMember(dest => dest.ProductID, source => source.MapFrom(src => src.ProductID))
            .ForMember(dest => dest.Quantity, source => source.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.OrderID, source => source.MapFrom(src => src.OrderID));
        }
    }
}
