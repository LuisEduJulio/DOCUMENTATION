using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DOCUMENTATION.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TopicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateTopic")]
        public async Task<IActionResult> PostAsync([FromBody] TopicCreateCommand topicCreateCommand)
        {
            var topic = await _mediator.Send(topicCreateCommand);

            return Ok(topic);
        }
    }
}