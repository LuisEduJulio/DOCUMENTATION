using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using DOCUMENTATION.APPLICATION.Querys.AuthorQuerys;
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
        public async Task<IActionResult> PostCreateAuthorAsync([FromBody] AuthorCreateCommand authorCreateCommand)
        {
            var topic = await _mediator.Send(authorCreateCommand);

            return Ok(topic);
        }

        [HttpGet("GetByIdAuthor/{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var getTopictByIdQuery = new GetAuthorByIdQuery(Id);

            var topic = await _mediator.Send(getTopictByIdQuery);

            return Ok(topic);
        }

        [HttpPut("UpdateAuthorAdmin")]
        public async Task<IActionResult> UpdateAdminAsync([FromBody] AuthorUpdateAdminCommand authorUpdateAdminCommand)
        {
            var topic = await _mediator.Send(authorUpdateAdminCommand);

            return Ok(topic);
        }

        [HttpPut("UpdateAuthorAvatar")]
        public async Task<IActionResult> UpdateAvatarAsync([FromBody] AuthorUpdateAvatarCommand authorUpdateAvatarCommand)
        {
            var topic = await _mediator.Send(authorUpdateAvatarCommand);

            return Ok(topic);
        }

        [HttpPut("DisableAuthor")]
        public async Task<IActionResult> UpdateDisableAsync([FromBody] AuthorUpdateDisableCommand authorUpdateDisableCommand)
        {
            var topic = await _mediator.Send(authorUpdateDisableCommand);

            return Ok(topic);
        }
    }
}