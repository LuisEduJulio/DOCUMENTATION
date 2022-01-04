using DOCUMENTATION.APPLICATION.Commands.ArticleCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.ArticleCommandValidators
{
    public class ArticleUpdateDisableCommandValidator : AbstractValidator<ArticleUpdateDisableCommand>
    {
        public ArticleUpdateDisableCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .WithMessage("Informe o artigo que deseja excluir!");
        }
    }
}