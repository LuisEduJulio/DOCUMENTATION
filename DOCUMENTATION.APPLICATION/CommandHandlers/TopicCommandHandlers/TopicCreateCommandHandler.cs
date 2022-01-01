using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using DOCUMENTATION.APPLICATION.ModelView.TopicView;
using DOCUMENTATION.APPLICATION.Validators.TopicValidators;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.TopicCommandHandlers
{
    public class TopicCreateCommandHandler : IRequestHandler<TopicCreateCommand, TopicView>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IAuthorRepository _authorRepository;

        public TopicCreateCommandHandler(ITopicRepository topicRepository, IAuthorRepository authorRepository)
        {
            _topicRepository = topicRepository;
            _authorRepository = authorRepository;
        }

        public async Task<TopicView> Handle(TopicCreateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new TopicCreateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var author = await _authorRepository.GetIdAsync(request.AuthorId);

            if(author == null)
            {
                throw new CustomException("Autor não existe!");
            }

            var topic = new Topic(request.Title, request.Description, author.Id, request?.TopicId);

            var topicCreate = await _topicRepository.AddAsync(topic);

            var topicCreateView = new TopicView()
            {
                Title = topicCreate.Title,
                Description = topicCreate.Description,
                AuthorId = author.Id,
                AuthorName = author.Name,
                AuthorDescription = author.Description,
                Creation = topic.DateCreation,
                TopicId = topicCreate.TopicId
            };               

            return topicCreateView;
        }
    }
}