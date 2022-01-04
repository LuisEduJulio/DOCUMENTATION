using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.CommentCommandValidators
{
    public class CommentCreateCommandValidator : AbstractValidator<CommentCreateCommand>
    {
        public CommentCreateCommandValidator()
        {            
        }
    }
}
