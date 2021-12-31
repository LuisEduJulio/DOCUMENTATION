using DOCUMENTATION.CORE.Entities;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.AuthorCommand
{
    public class AuthorUpdateAdminCommand : IRequest<Author>
    {
        public int Id { get; set; }
        public bool Admin { get; set; }
    }
}
