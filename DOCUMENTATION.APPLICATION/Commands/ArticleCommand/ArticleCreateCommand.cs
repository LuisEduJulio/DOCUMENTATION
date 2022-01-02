using DOCUMENTATION.APPLICATION.ModelView.ArticleView;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.ArticlesCommand
{
    public class ArticleCreateCommand : IRequest<ArticleView>
    {      
    {      
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public int AuthorId { get; set; }
    }
}
