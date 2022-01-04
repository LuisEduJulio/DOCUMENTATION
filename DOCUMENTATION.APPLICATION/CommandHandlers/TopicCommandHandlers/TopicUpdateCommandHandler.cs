﻿using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using DOCUMENTATION.APPLICATION.Validators.TopicValidators;
using DOCUMENTATION.CORE.Entities;
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

        public TopicUpdateCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
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

            topic.Title = request.Title ?? topic.Title;
            topic.Description = request.Description ?? topic.Description;
            topic.TopicId = topicSon?.Id ?? topic.TopicId;
            topic.DateUpdated = DateTime.Now;

            var topicUpdate = await _topicRepository.UpdateAsync(topic);

            return topicUpdate;
        }
    }
}