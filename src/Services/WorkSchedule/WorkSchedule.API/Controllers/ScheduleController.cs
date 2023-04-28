using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.Application.Features.Month.Commands.PrepareSchedule;
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

        [HttpGet("{monthName}")]
        [ProducesResponseType(typeof(WorkingMonth), 200)]
        [ProducesResponseType(typeof(WorkingMonth), 400)]
        [ProducesResponseType(typeof(WorkingMonth), 404)]
        public async Task<IActionResult> GetSchedule([FromRoute]string monthName, [FromQuery]string employeeName)
        {
            var query = new GetScheduleQuery(monthName, employeeName);
            var result = await _mediator.Send(query);

            return HandleResult(result);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PrepareSchedule([FromBody] WorkingMonth schedule)
        {
            var query = new PrepareScheduleRequest(schedule);
            var result = await _mediator.Send(query);

            return HandleResult(result);
        }
    }
}
