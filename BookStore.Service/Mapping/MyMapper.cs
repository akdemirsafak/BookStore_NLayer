using AutoMapper;
using BookStore.Core.Dtos.AuthorDtos;
using BookStore.Core.Dtos.BookDtos;
using BookStore.Core.Dtos.DisciplineDtos;
using BookStore.Core.Entity;

namespace BookStore.Service.Mapping;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.CreatedDate,
                opt => opt.MapFrom(src => src.CreatedDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.PublishDate,
                opt => opt.MapFrom(src => src.PublishDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => src.UpdatedDate.Value.ToString("dd/MM/yyyy")));


        /////// ! BOOK With Details DTO
        CreateMap<Book, BookWithDetailsDto>()
            .ForMember(dest => dest.Disciplines,
                opt =>
                    opt.MapFrom(src => src.Disciplines.Select(d => d.Discipline)));
        CreateMap<Author, AuthorForBookDetails>();
        CreateMap<Discipline, DisciplinesForBookDetails>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name));

        /////// ! BOOK With Details DTO END

        CreateMap<UpdateBookDto, Book>()
            .ForMember(dest => dest.AuthorId,
                opt => opt.MapFrom(src => src.AuthorId));

        CreateMap<CreateBookDto, Book>()
            .ForMember(dest => dest.AuthorId,
                opt => opt.MapFrom(src => src.AuthorId));
        CreateMap<BookDisciplineIdDto, BookDiscipline>();


        ///////// ! Author Mappings
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorWithBooksDto>();
        CreateMap<Book, AuthorBooksDto>();
        CreateMap<CreateAuthorDto, Author>();
        CreateMap<UpdateAuthorDto, Author>();


        CreateMap<Discipline, DisciplineDto>();

        CreateMap<Book, DisciplineBooksForRelation>();
        CreateMap<Discipline, DisciplineWithBooksDto>()
            .ForMember(dest => dest.Books,
                opt =>
                    opt.MapFrom(src => src.Books.Select(d => d.Book)));

        CreateMap<Discipline, DisciplinesForBookDetails>();


        CreateMap<CreateDisciplineDto, Discipline>();
        CreateMap<UpdateDisciplineDto, Discipline>();
    }
}