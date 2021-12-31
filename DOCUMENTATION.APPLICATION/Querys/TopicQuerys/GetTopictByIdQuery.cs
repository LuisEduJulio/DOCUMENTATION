using DOCUMENTATION.CORE.Entities;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Querys
{
    public class GetTopictByIdQuery : IRequest<Topic>
    {
        public GetTopictByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
