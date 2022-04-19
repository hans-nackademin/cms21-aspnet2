using AutoMapper;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductEntity>();
            CreateMap<ProductEntity, Product>();
            CreateMap<ProductCreateRequest, ProductEntity>();
        }
    }
}
