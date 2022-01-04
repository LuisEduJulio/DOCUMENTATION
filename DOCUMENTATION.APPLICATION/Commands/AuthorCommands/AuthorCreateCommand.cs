using DOCUMENTATION.CORE.Entities;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.AuthorCommand
{
    public class AuthorCreateCommand : IRequest<Author>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}