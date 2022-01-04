using DOCUMENTATION.APPLICATION.Querys;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.QueryHandlers.TopicQueryHandlers
{
    public class GetTopicAllQueryHandler : IRequestHandler<GetTopicAllQuery, List<Topic>>
    {
        private readonly ITopicRepository _topicRepository;

        public GetTopicAllQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<Topic>> Handle(GetTopicAllQuery request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.GetAllAsync();

            if (!topics.Any())
            {
                throw new CustomException("Tópicos não cadastrados");
            }

            return topics;
        }
    }
}