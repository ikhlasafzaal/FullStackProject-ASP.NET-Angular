using FullStackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly FullStackContext _FullStackContext;

        public EmployeesController(FullStackContext full_StackContext)
        {
            _FullStackContext = full_StackContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()
        {
            var emp = await _FullStackContext.Employees.ToListAsync();
            return Ok(emp);
        }

        [HttpPost]

        public async Task<IActionResult> AddEmployee(Employee empRequest)
        {
            empRequest.Id = Guid.NewGuid();
            await _FullStackContext.Employees.AddAsync(empRequest);
            await _FullStackContext.SaveChangesAsync();
            return Ok(empRequest);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var emp = _FullStackContext.Employees.Find(id);
            if (emp is not null)
            {
                _FullStackContext.Employees.Remove(emp);
                _FullStackContext.SaveChanges();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var emp = await _FullStackContext.Employees.FirstOrDefaultAsync(e => e.Id == id); 
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp); 
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditEmployee(Guid id, [FromBody] Employee request)
        {
            var emp = await _FullStackContext.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound("Employee not found");
            }

            emp.Name = request.Name;
            emp.Email = request.Email;
            emp.Phone = request.Phone;
            emp.Age = request.Age;
            emp.Salary = request.Salary;
            emp.Department = request.Department;

            await _FullStackContext.SaveChangesAsync();

            return Ok();
        }




    }
}
