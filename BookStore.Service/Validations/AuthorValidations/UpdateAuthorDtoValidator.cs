using BookStore.Core.Dtos.AuthorDtos;
using FluentValidation;

namespace BookStore.Service.Validations.AuthorValidations;

public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorDto>
{
    public UpdateAuthorDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.LastName).NotNull().NotEmpty();
    }
}