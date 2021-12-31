using DOCUMENTATION.APPLICATION.Querys;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.QueryHandlers.TopicQueryHandlers
{
    public class GetTopictByIdQueryHandler : IRequestHandler<GetTopictByIdQuery, Topic>
    {
        private readonly ITopicRepository _topicRepository;
        public GetTopictByIdQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Topic> Handle(GetTopictByIdQuery request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetIdAsync(request.Id);

            if (topic == null)
            {
                throw new CustomException("Tópico não encontrado");
            }

            return topic;
        }
    }
}
