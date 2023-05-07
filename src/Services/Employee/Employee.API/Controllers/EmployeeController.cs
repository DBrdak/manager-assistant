using Employee.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Employee>), 200)]
        public async Task<ActionResult<IEnumerable<Entities.Employee>>> GetEmployees() => 
            Ok(await _repository.GetEmployees());

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<Entities.Employee>), 400)]
        public async Task<IActionResult> HireEmployee([FromBody] Entities.Employee newEmployee)
            => await _repository.HireEmployee(newEmployee) ? Ok() : BadRequest();

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<Entities.Employee>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Entities.Employee>), 400)]
        public async Task<IActionResult> UpdateEmployeeData([FromBody] Entities.Employee employee) 
            => await _repository.UpdateEmployeeData(employee) ? Ok() : BadRequest();

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(typeof(IEnumerable<Entities.Employee>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Entities.Employee>), 400)]
        public async Task<IActionResult> FireEmployee(string employeeId)
            => await _repository.FireEmployee(employeeId) ? Ok() : BadRequest();
    }
}
