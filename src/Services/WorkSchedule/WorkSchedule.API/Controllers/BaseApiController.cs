using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.Application.Models;

namespace WorkSchedule.API.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>();

        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }

            if (result.Value == null && !result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return BadRequest(result.Message);
        }
    
    }
}
