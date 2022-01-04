using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators
{
    public class AuthorCreateCommandValidator : AbstractValidator<AuthorCreateCommand>
    {
        public AuthorCreateCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("Informe o nome do author!");

            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Informe a descrição do author!");
        }
    }
}