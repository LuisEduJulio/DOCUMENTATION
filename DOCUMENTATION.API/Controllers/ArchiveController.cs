using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DOCUMENTATION.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArchiveController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}