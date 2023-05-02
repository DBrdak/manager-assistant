using Microsoft.AspNetCore.Mvc;
using Payroll.API.Entities;
using Payroll.API.Repositories;

namespace Payroll.API.Controllers
{
    [ApiController]
    [Route("api/v1/payroll")]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollRepository _repository;

        public PayrollController(IPayrollRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Salary>), 200)]
        public async Task<ActionResult<IEnumerable<Salary>>> GetAllSalaries() => 
            Ok(await _repository.GetAllSalaries());

        [HttpGet("{employeeName}")]
        [ProducesResponseType(typeof(IEnumerable<Salary>), 200)]
        public async Task<ActionResult<IEnumerable<Salary>>> GetEmployeeSalaries(string employeeName) =>
            Ok(await _repository.GetSalariesByEmployee(employeeName));

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddPendingSalary([FromBody] Salary pendingSalary)
        {
            await _repository.AddPendingSalary(pendingSalary);

            return Ok();
        }

        [HttpPut("{salaryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PayoffSalary(string salaryId) =>
            await _repository.PayoffSalary(salaryId) ? Ok() : NotFound();

        [HttpDelete("{salaryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemovePendingSalary(string salaryId) =>
            await _repository.RemovePendingSalary(salaryId) ? Ok() : NotFound();
    }
}
