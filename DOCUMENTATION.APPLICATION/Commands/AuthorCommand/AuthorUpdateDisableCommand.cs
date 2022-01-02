using MediatR;

namespace DOCUMENTATION.APPLICATION.Commands.AuthorCommand
{
    public class AuthorUpdateDisableCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
