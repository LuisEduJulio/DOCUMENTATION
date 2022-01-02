using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators
{
    public class AuthorUpdateDisableCommandValidator : AbstractValidator<AuthorUpdateDisableCommand>
    {
        public AuthorUpdateDisableCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull()
                .When(t => t.Id == 0)
                .WithMessage("Informe o seu usuário!");
        }
    }
}
