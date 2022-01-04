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

            RuleFor(t => t.TopicId)
               .NotEmpty()
               .WithMessage("Informe o tópico que deseja adicionar o artigo!");

            RuleFor(t => t.AuthorId)
               .NotEmpty()
               .WithMessage("Informe o autor do artigo!");
        }
    }
}