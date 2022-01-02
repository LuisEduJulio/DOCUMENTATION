using AutoMapper;
using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using DOCUMENTATION.APPLICATION.ModelView.TopicView;
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
    public class TopicCreateCommandHandler : IRequestHandler<TopicCreateCommand, TopicView>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public TopicCreateCommandHandler(ITopicRepository topicRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
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

            var topic = new Topic(request.Title, request.Description, author.Id, topicSon?.Id);

            var topicCreate = await _topicRepository.AddAsync(topic);

            var topicCreateView = new TopicView();

            var returnTopic = _mapper.Map<Topic, TopicView>(topicCreate, topicCreateView);
           
            return returnTopic;
        }
    }
}