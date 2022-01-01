using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Enums;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.AuthorCommand
{
    public class AuthorUpdateAvatarCommand : IRequest<Author>
    {
        public int Id { get; set; }
        public EAvatar EAvatar { get; set; }
    }
}
