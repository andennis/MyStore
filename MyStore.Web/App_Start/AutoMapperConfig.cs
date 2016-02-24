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
            });
        }
    }
}
