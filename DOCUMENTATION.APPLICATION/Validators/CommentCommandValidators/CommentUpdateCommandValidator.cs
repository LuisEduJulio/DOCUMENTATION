using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.CommentCommandValidators
{
    public class CommentUpdateCommandValidator : AbstractValidator<CommentUpdateCommand>
    {
        public CommentUpdateCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .WithMessage("Informe o comentário que deseja alterar!");

            RuleFor(t => t.Description)
               .NotEmpty()
               .WithMessage("Informe o comentário!");
        }
    }
}