using AutoMapper;
using BookStore.Core.Dtos.BookOperations;
using BookStore.Core.Entity;

namespace BookStore.Service.Mapping;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.CreationDate,
                opt => opt.MapFrom(src => src.CreationDate.ToString("dd/MM/yyyy")))
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
    }
}