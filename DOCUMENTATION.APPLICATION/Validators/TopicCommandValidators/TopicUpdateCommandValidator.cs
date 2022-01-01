using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.TopicValidators
{
    public class TopicUpdateCommandValidator : AbstractValidator<TopicUpdateCommand>
    {
        public TopicUpdateCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull()
                .When(t => t.Id == 0)
                .WithMessage("Informe o id do tópico!");

            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("Informe o título do tópico!");

            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Informe a descrição do tópico!");
        }
    }
}
