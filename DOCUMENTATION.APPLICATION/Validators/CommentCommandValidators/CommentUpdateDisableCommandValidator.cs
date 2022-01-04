using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.CommentCommandValidators
{
    public class CommentUpdateDisableCommandValidator : AbstractValidator<CommentUpdateDisableCommand>
    {
        public CommentUpdateDisableCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .WithMessage("Informe o comentário que deseja excluir!");
        }
    }
}