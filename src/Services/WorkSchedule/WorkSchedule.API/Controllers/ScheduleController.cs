using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.Application.Features.Month.Queries.GetMonth;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.API.Controllers
{
    [ApiController]
    [Route("/api/v1/schedule")]
    public class ScheduleController : BaseApiController
    {
        private IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{month}")]
        [ProducesResponseType(typeof(WorkingMonth), 200)]
        public async Task<IActionResult> GetSchedule(string month)
        {
            var query = new GetScheduleQuery(month);
            var result = await _mediator.Send(query);

            return HandleResult(result);
        }
    }
}
