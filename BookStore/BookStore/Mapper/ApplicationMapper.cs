using AutoMapper;
using BookStore.DTO;
using BookStore.Models;

namespace BookStore.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookDTORequest>();
        }
    }
}
