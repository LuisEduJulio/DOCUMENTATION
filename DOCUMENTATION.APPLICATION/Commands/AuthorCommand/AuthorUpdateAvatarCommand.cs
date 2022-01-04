using DOCUMENTATION.APPLICATION.ModelView.AuthorView;
using DOCUMENTATION.CORE.Enums;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.AuthorCommand
{
    public class AuthorUpdateAvatarCommand : IRequest<AuthorView>
    {
        public int Id { get; set; }
        public EAvatar EAvatar { get; set; }
    }
}