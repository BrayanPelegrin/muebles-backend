using AutoMapper;
using MueblesDiamante.Models.DTO;
using MueblesDiamante.Models.Entities;

namespace MueblesDiamante.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Product, ProductCreacionDTO>().ReverseMap();
            CreateMap<Status, StatusCreacionDTO>().ReverseMap();
            CreateMap<Category, CategoryCreacionDTO>().ReverseMap();

        }
    }
}
