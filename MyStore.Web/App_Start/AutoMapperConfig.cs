using AutoMapper;
using MyStore.Core.Entities;
using MyStore.Web.Models;

namespace MyStore.Web
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                cfg.CreateMap<Client, ClientViewModel>().ReverseMap();

                cfg.CreateMap<Order, OrderViewModel>()
                    .ForMember(dst => dst.ClientName, x => x.MapFrom(src => src.Client.FirstName+" "+src.Client.LastName));
                cfg.CreateMap<OrderViewModel, Order>();

                cfg.CreateMap<OrderItem, OrderItemViewModel>()
                    .ForMember(dst => dst.ProductName, x => x.MapFrom(src => src.Product.Name))
                    .ForMember(dst => dst.ProductPrice, x => x.MapFrom(src => src.Product.Price));
                cfg.CreateMap<OrderItemViewModel, OrderItem>();

                cfg.CreateMap<BasketItem, BasketItemViewModel>()
                    .ForMember(dst => dst.ProductName, x => x.MapFrom(src => src.Product.Name))
                    .ForMember(dst => dst.ProductPrice, x => x.MapFrom(src => src.Product.Price));
                cfg.CreateMap<BasketItemViewModel, BasketItem>()
                    .ForMember(dst => dst.ClientId, x => x.Ignore())
                    .ForMember(dst => dst.ProductId, x => x.Ignore());
            });
        }
    }
}
