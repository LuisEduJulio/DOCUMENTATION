using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators
{
    public class AuthorUpdateAdminCommandValidator : AbstractValidator<AuthorUpdateAdminCommand>
    {
        public AuthorUpdateAdminCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull()
                .When(t => t.Id == 0)
                .WithMessage("Informe o id do author!");

            RuleFor(t => t.Admin)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe a mudança de tipo de usuário do author!");
        }
    }
}
