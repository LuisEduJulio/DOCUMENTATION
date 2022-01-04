using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.ArticleCommand
{
    public class ArticleUpdateDisableCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}