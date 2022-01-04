using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.TopicCommands
{
    public class TopicDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}