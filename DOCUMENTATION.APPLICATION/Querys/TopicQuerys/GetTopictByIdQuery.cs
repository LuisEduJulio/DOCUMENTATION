using DOCUMENTATION.APPLICATION.ModelView.TopicView;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Querys
{
    public class GetTopictByIdQuery : IRequest<TopicView>
    {
        public GetTopictByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
