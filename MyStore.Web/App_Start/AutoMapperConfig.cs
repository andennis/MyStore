using AutoMapper;
using MyStore.Core.Entities;

namespace MyStore.Web
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
