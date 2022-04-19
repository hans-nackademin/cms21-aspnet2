using AutoMapper;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductEntity>();
            CreateMap<ProductEntity, Product>();
            CreateMap<ProductRequest, ProductEntity>();
        }
    }
}