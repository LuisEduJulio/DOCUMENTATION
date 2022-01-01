using DOCUMENTATION.APPLICATION.ModelView.TopicView;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.TopicCommands
{
    public class TopicCreateCommand : IRequest<TopicView>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TopicId { get; set; }
        public int AuthorId { get; set; }
    }
}