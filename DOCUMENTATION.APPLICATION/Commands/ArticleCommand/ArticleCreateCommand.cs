using DOCUMENTATION.CORE.Entities;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.ArticlesCommand
{
    public class ArticleCreateCommand : IRequest<Article>
    {      
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public int AuthorId { get; set; }
    }
}
