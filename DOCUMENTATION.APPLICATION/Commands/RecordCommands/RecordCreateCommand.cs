using DOCUMENTATION.CORE.Enums;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.RecordCommands
{
    public class RecordCreateCommand : IRequest
    {
        public string Description { get; set; }
        public EStatusRecord EStatusRecord { get; set; }
        public int AuthorId { get; set; }
        public int? TopicId { get; set; }
        public int? ArticleId { get; set; }
        public int? CommentId { get; set; }
    }
}