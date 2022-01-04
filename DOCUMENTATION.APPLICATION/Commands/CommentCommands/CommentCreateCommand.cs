using DOCUMENTATION.APPLICATION.ModelView.CommentView;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.CommentCommand
{
    public class CommentCreateCommand : IRequest<CommentView>
    {
        public string Description { get; set; }
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
    }
}