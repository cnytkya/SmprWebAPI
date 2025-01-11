using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmprWebAPI.Server.Models;
using SmprWebAPI.Server.Repository;

namespace SmprWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository; // DI for EmployeeRepository: Burası EmployeeRepository sınıfı için DI yapıldı.

        public EmployeeController(EmployeeRepository employeeRepository)// DI for EmployeeRepository: Burada constructor injection yapıldı.
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _employeeRepository.SaveEmp(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var emp = await _employeeRepository.GetEmpById(id);
            if (emp == null)
            {
                return NotFound(new { Message = "Employee not found" });
            }
            await _employeeRepository.DeleteEmp(id);
            return Ok(new { Message = "Employee deleted successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest(new { Message = "Employee Id mismatch" });
            }
            var existingEmployee = await _employeeRepository.GetEmpById(employee.Id);
            if (existingEmployee == null)
            {
                return NotFound(new { Message = "Employee not found" });
            }
            await _employeeRepository.UpdateEmp(employee);
            return Ok(new { Message = "Employee updated successfully" });
        }
    }
}