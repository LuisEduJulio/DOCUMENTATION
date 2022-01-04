using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.CommentCommand
{
    public class CommentUpdateDisableCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}