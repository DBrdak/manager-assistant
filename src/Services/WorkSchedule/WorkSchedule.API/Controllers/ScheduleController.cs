using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.Application.Features.Commands.RemoveAvailability;
using WorkSchedule.Application.Features.Commands.RemoveSchedule;
using WorkSchedule.Application.Features.Month.Commands.AddAvailability;
using WorkSchedule.Application.Features.Month.Commands.ApproveMonth;
using WorkSchedule.Application.Features.Month.Commands.PrepareSchedule;
using WorkSchedule.Application.Features.Month.Commands.UpdateAvailability;
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
            var query = new PrepareScheduleCommand(schedule);
            var result = await _mediator.Send(query);

            return HandleResult(result);
        }

        [HttpPost("{monthName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAvailability([FromBody] AddAvailabilityCommand command)
        {
            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        [HttpPut("{monthName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ApproveSchedule([FromRoute] string monthName)
        {
            var command = new ApproveScheduleCommand(monthName);
            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        [HttpDelete("{monthName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveSchedule([FromRoute] string monthName)
        {
            var command = new RemoveScheduleCommand(monthName);
            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        [HttpDelete("{monthName}/{shiftId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveAvailability([FromRoute] Guid shiftId)
        {
            var command = new RemoveAvailabilityCommand(shiftId);
            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        [HttpPut("{monthName}/{shiftId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateShift([FromBody] Domain.Entities.Shift shift)
        {
            var command = new UpdateShiftCommand(shift);
            var result = await _mediator.Send(command);

            return HandleResult(result);
        }
    }
}
