using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.TopicValidators
{
    public class TopicDeleteCommandValidator : AbstractValidator<TopicDeleteCommand>
    {
        public TopicDeleteCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull()
                .When(t => t.Id == 0)
                .WithMessage("Informe o tópico que deseja excluir!");
        }
    }
}