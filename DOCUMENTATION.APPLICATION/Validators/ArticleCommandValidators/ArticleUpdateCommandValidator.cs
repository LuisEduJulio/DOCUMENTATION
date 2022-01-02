using DOCUMENTATION.APPLICATION.Commands.ArticleCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.ArticleCommandValidators
{
    public class ArticleUpdateCommandValidator : AbstractValidator<ArticleUpdateCommand>
    {
        public ArticleUpdateCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .WithMessage("Informe o artigo!");

            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("Informe o título artigo!");

            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Informe a descrição do artigo!");
        }
    }
}
