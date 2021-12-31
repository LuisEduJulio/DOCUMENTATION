using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using DOCUMENTATION.APPLICATION.Validators.TopicValidators;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.TopicCommandHandlers
{
    public class TopicDeleteCommandHandler : IRequestHandler<TopicDeleteCommand, Unit>
    {
        private readonly ITopicRepository _topicRepository;
        public TopicDeleteCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Unit> Handle(TopicDeleteCommand request, CancellationToken cancellationToken)
        {
            var validation = await new TopicDeleteCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var topic = await _topicRepository.GetIdAsync(request.Id);

            topic.DateDeleted = DateTime.Now;

            await _topicRepository.UpdateAsync(topic);

            return Unit.Value;
        }
    }
}
