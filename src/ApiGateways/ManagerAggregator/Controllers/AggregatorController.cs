using ManagerAggregator.Models;
using ManagerAggregator.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAggregator.Controllers
{
    [ApiController]
    [Route("api/v1/aggregator")]
    public class AggregatorController : ControllerBase
    {
        private readonly IAggregatorService _aggregatorService;

        public AggregatorController(IAggregatorService aggregatorService)
        {
            _aggregatorService = aggregatorService;
        }

        [HttpGet("{employeeName}")]
        public async Task<ActionResult<AggregatedEmployee>> GetAggregatedData(string employeeName) =>
            await _aggregatorService.GetAggregatedEmployeeData(employeeName);
    }
}
