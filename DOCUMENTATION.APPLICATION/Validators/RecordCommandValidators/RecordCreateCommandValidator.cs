using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.RecordCommandValidators
{
    public class RecordCreateCommandValidator : AbstractValidator<RecordCreateCommand>
    {
        public RecordCreateCommandValidator()
        {
            RuleFor(t => t.Description)
               .NotEmpty()
               .WithMessage("Informe o comentário!");

            RuleFor(t => t.EStatusRecord)
              .NotEmpty()
              .WithMessage("Informe o status de histórico!");
        }
    }
}