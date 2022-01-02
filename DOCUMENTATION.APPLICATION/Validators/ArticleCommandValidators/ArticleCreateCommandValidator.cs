using DOCUMENTATION.APPLICATION.Commands.ArticlesCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.ArticleCommandValidators
{
    public class ArticleCreateCommandValidator : AbstractValidator<ArticleCreateCommand>
    {
        public ArticleCreateCommandValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("Informe o título artigo!");

            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Informe a descrição do artigo!");
        }
    }
}
