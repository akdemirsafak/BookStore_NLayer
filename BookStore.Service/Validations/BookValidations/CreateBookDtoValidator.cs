using BookStore.Core.Dtos.BookDtos;
using FluentValidation;

namespace BookStore.Service.Validations.BookValidations;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .Length(3, 64).WithMessage("{PropertyName} must be 3-64 chars.");
        RuleFor(x => x.Description)
            .MaximumLength(512).WithMessage("{PropertyName} must be a maximum of 512 characters long.");
        RuleFor(x => x.Price).NotNull().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.AuthorId).NotNull().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.Disciplines).NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.");
    }
}