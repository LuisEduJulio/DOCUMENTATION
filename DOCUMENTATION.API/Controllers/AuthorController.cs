using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DOCUMENTATION.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> PostAsync([FromBody] AuthorCreateCommand authorCreateCommand)
        {
            var topic = await _mediator.Send(authorCreateCommand);

            return Ok(topic);
        }

        [HttpPost("UpdateAuthorAdmin")]
        public async Task<IActionResult> UpdateAdminAsync([FromBody] AuthorUpdateAdminCommand authorUpdateAdminCommand)
        {
            var topic = await _mediator.Send(authorUpdateAdminCommand);

            return Ok(topic);
        }
    }
}