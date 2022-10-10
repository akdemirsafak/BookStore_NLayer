using BookStore.Core.Dtos.DisciplineDtos;
using FluentValidation;

namespace BookStore.Service.Validations.DisciplineValidations;

public class UpdateDisciplineDtoValidator : AbstractValidator<UpdateDisciplineDto>
{
    public UpdateDisciplineDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .Length(3, 64).WithMessage("{PropertyName} must be 3-64 chars.");
    }
}