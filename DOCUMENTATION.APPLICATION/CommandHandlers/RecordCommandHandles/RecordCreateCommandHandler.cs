using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.Validators.RecordCommandValidators;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.RecordCommandHandles
{
    public class RecordCreateCommandHandler : IRequestHandler<RecordCreateCommand>
    {
        private readonly IRecordRepository _recordRepository;

        public RecordCreateCommandHandler(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task<Unit> Handle(RecordCreateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new RecordCreateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var record = new Record()
            {
                Description = request.Description,
                AuthorId = request.AuthorId,
                EStatusRecord = request.EStatusRecord,
                TopicId = request?.TopicId,
                ArticleId = request?.ArticleId,
                CommentId = request?.CommentId
            };

            await _recordRepository.AddAsync(record);

            return Unit.Value;
        }
    }
}