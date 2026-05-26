using FluentValidation;
using Users.Api.Dtos;

namespace Users.Api.Validator;

public class CreateUserValidator:AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().WithMessage("full name cannot be null or empty");
        RuleFor(x => x.FullName).MinimumLength(3).WithMessage("full name must be greater than 3 letter");
    }
}
