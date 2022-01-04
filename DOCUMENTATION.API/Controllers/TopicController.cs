using DOCUMENTATION.APPLICATION.Commands.TopicCommands;
using DOCUMENTATION.APPLICATION.Querys;
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
        public async Task<IActionResult> PostCreateTopicAsync([FromBody] TopicCreateCommand topicCreateCommand)
        {
            var topic = await _mediator.Send(topicCreateCommand);

            return Ok(topic);
        }

        [HttpGet("GetAllTopic")]
        public async Task<IActionResult> GetAllAsync()
        {
            var topic = await _mediator.Send(new GetTopicAllQuery());

            return Ok(topic);
        }

        [HttpGet("GetByIdTopic/{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var getTopictByIdQuery = new GetTopictByIdQuery(Id);

            var topic = await _mediator.Send(getTopictByIdQuery);

            return Ok(topic);
        }

        [HttpPut("UpdateTopic")]
        public async Task<IActionResult> UpdateTopicAsync([FromBody] TopicUpdateCommand topicUpdateCommand)
        {
            var topic = await _mediator.Send(topicUpdateCommand);

            return Ok(topic);
        }

        [HttpPut("DeleteTopic")]
        public async Task<IActionResult> DeleteTopicAsync([FromBody] TopicDeleteCommand topicDeleteCommand)
        {
            var topic = await _mediator.Send(topicDeleteCommand);

            return Ok(topic);
        }
    }
}