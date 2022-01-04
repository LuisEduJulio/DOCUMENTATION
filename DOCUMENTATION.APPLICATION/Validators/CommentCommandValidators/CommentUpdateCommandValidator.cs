using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using FluentValidation;

namespace DOCUMENTATION.APPLICATION.Validators.CommentCommandValidators
{
    class CommentUpdateCommandValidator : AbstractValidator<CommentUpdateCommand>
    {
        public CommentUpdateCommandValidator()
        {
        }
    }
}