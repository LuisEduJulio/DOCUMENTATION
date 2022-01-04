using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DOCUMENTATION.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> PostCreateCommentAsync([FromBody] CommentCreateCommand commentCreateCommand)
        {
            var topic = await _mediator.Send(commentCreateCommand);

            return Ok(topic);
        }

        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateCommentAsync([FromBody] CommentUpdateCommand commentUpdateCommand)
        {
            var topic = await _mediator.Send(commentUpdateCommand);

            return Ok(topic);
        }

        [HttpPut("DisableComment")]
        public async Task<IActionResult> UpdateDisableCommentAsync([FromBody] CommentUpdateDisableCommand commentUpdateDisableCommand)
        {
            var topic = await _mediator.Send(commentUpdateDisableCommand);

            return Ok(topic);
        }
    }
}