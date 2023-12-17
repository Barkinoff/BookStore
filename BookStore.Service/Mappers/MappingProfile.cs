using AutoMapper;
using BookStore.Domain.Entites;
using BookStore.Service.DTOs.BookDTOs;
using BookStore.Service.DTOs.CategoryDTOs;
using BookStore.Service.ViewModels;

namespace BookStore.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Category mapping
            CreateMap<Category, CategoryForCreationDTOs>().ReverseMap();
            CreateMap<Category, CategoryForUpdateDTOs>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();


            //Book mapping
            CreateMap<Book, BookForCreationDTO>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
