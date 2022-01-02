using DOCUMENTATION.APPLICATION.ModelView.AuthorView;
using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.AuthorCommand
{
    public class AuthorUpdateAdminCommand : IRequest<AuthorView>
    {
        public int Id { get; set; }
        public bool Admin { get; set; }
    }
}
