using AutoMapper;
using DOCUMENTATION.APPLICATION.ModelView.TopicView;
using DOCUMENTATION.APPLICATION.Querys;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.QueryHandlers.TopicQueryHandlers
{
    public class GetTopictByIdQueryHandler : IRequestHandler<GetTopictByIdQuery, TopicView>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IAuthorRepository _authorRepository;
             private readonly IMapper _mapper;
        public GetTopictByIdQueryHandler(ITopicRepository topicRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<TopicView> Handle(GetTopictByIdQuery request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetIdAsync(request.Id);

            if (topic == null)
            {
                throw new CustomException("Tópico não encontrado");
            }

            var author = await _authorRepository.GetIdAsync(topic.AuthorId);

            var topicCreateView = new TopicView();

            var returnTopic = _mapper.Map<Topic, TopicView>(topic, topicCreateView);

            returnTopic.AuthorName = author.Name;
            returnTopic.AuthorDescription = author.Description;

            return returnTopic;
        }
    }
}
