using DOCUMENTATION.APPLICATION.ModelView.TopicView;
using DOCUMENTATION.APPLICATION.Querys;
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
        public GetTopictByIdQueryHandler(ITopicRepository topicRepository, IAuthorRepository authorRepository)
        {
            _topicRepository = topicRepository;
            _authorRepository = authorRepository;
        }

        public async Task<TopicView> Handle(GetTopictByIdQuery request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetIdAsync(request.Id);

            if (topic == null)
            {
                throw new CustomException("Tópico não encontrado");
            }

            var author = await _authorRepository.GetIdAsync(topic.AuthorId);

            var topicCreateView = new TopicView()
            {
                Title = topic.Title,
                Description = topic.Description,
                AuthorId = author.Id,
                AuthorName = author.Name,
                AuthorDescription = author.Description,
                Creation = topic.DateCreation,
                TopicId = topic.TopicId
            };

            return topicCreateView;
        }
    }
}
