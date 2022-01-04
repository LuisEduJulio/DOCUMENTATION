using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.TopicValidators
{
    public class TopicCreateCommandValidator : AbstractValidator<TopicCreateCommand>
    {
        public TopicCreateCommandValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("Informe o título do tópico!");

            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Informe a descrição do tópico!");

            RuleFor(t => t.AuthorId)
               .NotEmpty()
               .WithMessage("Informe o criador do tópico!");
        }
    }
}