using DOCUMENTATION.CORE.Entities;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.TopicCommands
{
    public class TopicCreateCommand : IRequest<Topic>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TopicId { get; set; }
    }
}