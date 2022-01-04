using DOCUMENTATION.CORE.Entities;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Querys.AuthorQuerys
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}