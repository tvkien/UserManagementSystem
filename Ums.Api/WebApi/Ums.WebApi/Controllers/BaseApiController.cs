using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ums.WebApi.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        public readonly IMediator mediator;

        protected BaseApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}