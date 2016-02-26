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
            });
        }
    }
}
