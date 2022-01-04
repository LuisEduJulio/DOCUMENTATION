using DOCUMENTATION.APPLICATION.ModelView.CommentView;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.CommentCommand
{
    public class CommentUpdateCommand : IRequest<CommentView>
    {
    }
}
