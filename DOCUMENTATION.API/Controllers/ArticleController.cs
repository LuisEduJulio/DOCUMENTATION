using DOCUMENTATION.APPLICATION.Commands.ArticleCommand;
using DOCUMENTATION.APPLICATION.Commands.ArticlesCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DOCUMENTATION.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateArticle")]
        public async Task<IActionResult> PostCreateArticleAsync([FromBody] ArticleCreateCommand articleCreateCommand)
        {
            var topic = await _mediator.Send(articleCreateCommand);

            return Ok(topic);
        }

        [HttpPut("UpdateArticle")]
        public async Task<IActionResult> UpdateArticleAsync([FromBody] ArticleUpdateCommand articleUpdateCommand)
        {
            var topic = await _mediator.Send(articleUpdateCommand);

            return Ok(topic);
        }

        [HttpPut("DisableArticle")]
        public async Task<IActionResult> UpdateDisableArticleAsync([FromBody] ArticleUpdateDisableCommand articleUpdateDisableCommand)
        {
            var topic = await _mediator.Send(articleUpdateDisableCommand);

            return Ok(topic);
        }
    }
}