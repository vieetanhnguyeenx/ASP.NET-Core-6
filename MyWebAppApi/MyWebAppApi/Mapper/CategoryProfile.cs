using AutoMapper;
using MyWebAppApi.Dtos.Category;
using MyWebAppApi.Entity;

namespace MyWebAppApi.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTORequest, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Category, CategoryDTORequest>();

            CreateMap<CategoryDTOResponse, Category>();

            CreateMap<Category, CategoryDTOResponse>();
        }
    }
}
