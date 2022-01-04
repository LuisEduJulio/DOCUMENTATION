using DOCUMENTATION.CORE.Entities;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.CommentCommand
{
    public class CommentCreateCommand : IRequest<Comment>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
    }
}