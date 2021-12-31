using DOCUMENTATION.APPLICATION.Commands.ArticlesCommand;
using DOCUMENTATION.CORE.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.ArticlesCommandHandler
{
    public class ArticleCreateCommandHandler : IRequestHandler<ArticleCreateCommand, Article>
    {
        public ArticleCreateCommandHandler()
        {
        }

        public Task<Article> Handle(ArticleCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
