using Application.Categories.Queries.GetCategoryList;
using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderdList
{
    public class OrderLookupDto: IMapWith<Order>
    {
        public Guid Id { get; set; }
        public Worker Worker { get; set; }
        public User Customer { get; set; }

        public string Title { get; set; }
        public int Price { get; set; }
        public string State { get; set; }
        public List<Category> Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(orderDto => orderDto.Id,
                    otp => otp.MapFrom(order => order.Id))
                .ForMember(orderDto => orderDto.Worker,
                    otp => otp.MapFrom(order => order.Worker))
                .ForMember(orderDto => orderDto.Customer,
                    otp => otp.MapFrom(order => order.Customer))
                .ForMember(orderDto => orderDto.Title,
                    otp => otp.MapFrom(order => order.Title))
                .ForMember(orderDto => orderDto.Price,
                    otp => otp.MapFrom(order => order.Price))
                .ForMember(orderDto => orderDto.State,
                    otp => otp.MapFrom(order => order.State))
                .ForMember(orderDto => orderDto.Categories,
                    otp => otp.MapFrom(order => order.categories))
                ;
        }

    }
}
