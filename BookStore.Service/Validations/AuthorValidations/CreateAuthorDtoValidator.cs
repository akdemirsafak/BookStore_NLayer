using BookStore.Core.Dtos.AuthorDtos;
using FluentValidation;

namespace BookStore.Service.Validations.AuthorValidations;

public class CreateAuthorDtoValidator : AbstractValidator<CreateAuthorDto>
{
    public CreateAuthorDtoValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.LastName).NotNull().NotEmpty();
    }
}