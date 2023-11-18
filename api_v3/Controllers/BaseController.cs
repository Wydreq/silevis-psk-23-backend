using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_v3.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        
    }
}
