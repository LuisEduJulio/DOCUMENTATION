using DOCUMENTATION.APPLICATION.ModelView.ArticleView;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.ArticleCommand
{
    public class ArticleUpdateCommand : IRequest<ArticleView>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}