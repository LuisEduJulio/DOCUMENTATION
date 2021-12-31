using DOCUMENTATION.APPLICATION.Commands.ArticleCommand;
using DOCUMENTATION.CORE.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.ArticlesCommandHandler
{
    public class ArticleUpdateCommandHandler : IRequestHandler<ArticleUpdateCommand, Article>
    {
        public ArticleUpdateCommandHandler()
        {
        }
    
        public Task<Article> Handle(ArticleUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
