using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators
{
    public class AuthorUpdateAvatarCommandValidator : AbstractValidator<AuthorUpdateAvatarCommand>
    {
        public AuthorUpdateAvatarCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull()
                .When(t => t.Id == 0)
                .WithMessage("Informe o seu usuário!");

            RuleFor(t => t.EAvatar)
                .NotEmpty()
                .WithMessage("Informe o avatar que deseja alterar!");
        }
    }
}