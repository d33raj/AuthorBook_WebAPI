using AuthorWebApi.DTO;
using AuthorWebApi.Models;
using AutoMapper;

namespace AuthorWebApi.Mappers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDto>().
                ForMember(dest=> dest.TotalBooks,value=>value.MapFrom(src=>src.Book.Count));
            CreateMap<AuthorDto, Author>();


            CreateMap<AuthorDetail, AuthorDetailsDto>().
                ForMember(dest => dest.NameOfAuthor, value => value.MapFrom(src => src.Author.AuthorName));
            CreateMap<AuthorDetailsDto, AuthorDetail>();

            CreateMap<Book, BookDto>().
                ForMember(dest => dest.AId, value => value.MapFrom(src => src.AId));
            CreateMap<BookDto, Book>();
        }
    }
}
