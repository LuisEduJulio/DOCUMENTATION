using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.CommentCommandValidators
{
    public class CommentCreateCommandValidator : AbstractValidator<CommentCreateCommand>
    {
        public CommentCreateCommandValidator()
        {
            RuleFor(t => t.Description)
               .NotEmpty()
               .WithMessage("Informe o comentário!");

            RuleFor(t => t.ArticleId)
               .NotEmpty()
               .WithMessage("Informe o artigo que deseja comentar!");

            RuleFor(t => t.AuthorId)
               .NotEmpty()
               .WithMessage("Informe o autor do comentário!");
        }
    }
}