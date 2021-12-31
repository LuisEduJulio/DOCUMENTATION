using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
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
    public class TopicCreateCommandHandler : IRequestHandler<TopicCreateCommand, Topic>
    {
        private readonly ITopicRepository _topicRepository;

        public TopicCreateCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Topic> Handle(TopicCreateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new TopicCreateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var topic = new Topic(request.Title, request.Description, request?.TopicId);

            var topicCreate = await _topicRepository.AddAsync(topic);

            return topicCreate;
        }
    }
}