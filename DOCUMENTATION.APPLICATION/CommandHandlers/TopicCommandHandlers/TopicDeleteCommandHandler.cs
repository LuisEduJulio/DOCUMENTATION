using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using DOCUMENTATION.APPLICATION.Validators.TopicValidators;
using DOCUMENTATION.CORE.Enums;
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
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public TopicDeleteCommandHandler(ITopicRepository topicRepository, IAuthorRepository authorRepository, IMediator mediator)
        {
            _topicRepository = topicRepository;
            _authorRepository = authorRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(TopicDeleteCommand request, CancellationToken cancellationToken)
        {
            var validation = await new TopicDeleteCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var topic = await _topicRepository.GetIdAsync(request.Id);

            topic.DateUpdated = DateTime.Now;
            topic.DateDeleted = DateTime.Now;

            await _topicRepository.UpdateAsync(topic);

            var author = await _authorRepository.GetIdAsync(topic.AuthorId);

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.DISABLE,
                Description = $"Tópico desativado em {DateTime.Now} por {author.Name}.",
                AuthorId = topic.AuthorId,
                TopicId = topic.Id
            }, cancellationToken);

            return Unit.Value;
        }
    }
}