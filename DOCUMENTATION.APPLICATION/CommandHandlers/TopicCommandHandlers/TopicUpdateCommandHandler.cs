using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using DOCUMENTATION.APPLICATION.Validators.TopicValidators;
using DOCUMENTATION.CORE.Entities;
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
    public class TopicUpdateCommandHandler : IRequestHandler<TopicUpdateCommand, Topic>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public TopicUpdateCommandHandler(ITopicRepository topicRepository, IAuthorRepository authorRepository, IMediator mediator)
        {
            _topicRepository = topicRepository;
            _authorRepository = authorRepository;
            _mediator = mediator;
        }

        public async Task<Topic> Handle(TopicUpdateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new TopicUpdateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var topic = await _topicRepository.GetIdAsync(request.Id);

            if (topic == null)
            {
                throw new CustomException("Tópico não existe!");
            }

            var topicSon = await VeriFyExistTopicSon(request);

            topic.Title = request.Title ?? topic.Title;
            topic.Description = request.Description ?? topic.Description;
            topic.TopicId = request.TopicId != null ? topicSon?.Id : null;
            topic.DateUpdated = DateTime.Now;

            var topicUpdate = await _topicRepository.UpdateAsync(topic);

            var author = await _authorRepository.GetIdAsync(topic.AuthorId);

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.UPDATE,
                Description = $"Tópico alterado em {DateTime.Now} por {author.Name}.",
                AuthorId = topic.AuthorId,
                TopicId = topic.Id
            }, cancellationToken);

            return topicUpdate;
        }

        private async Task<Topic> VeriFyExistTopicSon(TopicUpdateCommand request)
        {
            var topicSon = new Topic();

            if (request.TopicId != null)
            {
                int verifyTopicId = Convert.ToInt32(request.TopicId);

                var verifyTopicSonExist = await _topicRepository.GetIdAsync(verifyTopicId);

                if (verifyTopicSonExist == null)
                {
                    throw new CustomException("Erro ao adicionar Tópico em outro tópico!");
                }

                topicSon.Id = verifyTopicSonExist.Id;
            }

            return topicSon;
        }
    }
}