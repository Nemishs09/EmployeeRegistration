using EmployeeRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
 
        
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var employee= await _context.Employee.ToListAsync();
            return Ok(employee);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpGet("Supervisor")]
        public async Task<ActionResult<IEnumerable<Supervisor>>> GetSupervisor()
        {
            return await _context.Supervisor.ToListAsync();
        }
        [HttpGet("Supervisor/{id}")]
        public async Task<ActionResult<Supervisor>> GetSupervisor(int id)
        {
            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }
            return supervisor;
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(Employee Employee)
        {

            //if (ModelState.IsValid)
            //{
            //await _context.Employee.AddAsync(Employee);
            //await _context.SaveChangesAsync();
                
                var existEmployee = await _context.Employee.FirstOrDefaultAsync(x => x.FirstName == Employee.FirstName);
                if (Employee == existEmployee)
                {
                    await _context.Employee.AddAsync(Employee);
                    await _context.SaveChangesAsync();
                    return Ok(Employee);
                }
                else
                {
                    _context.Employee.Update(Employee);
                    await _context.SaveChangesAsync();
                    return Ok(existEmployee);
                }
            

            return Ok("something went wrong");
        }

        [HttpPost("CreateSupervisor")]
        public async Task<IActionResult> CreateSupervisor(Supervisor Supervisor)
        {
            if (ModelState.IsValid)
            {
                await _context.Supervisor.AddAsync(Supervisor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSupervisor", new { Supervisor.Id }, Supervisor);
            }
            return Ok("something went wrong");
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int Id, Employee Employee)
        {
            if (Id != Employee.Id)
            {
                return BadRequest();
            }
            var exitstEmployee = await _context.Employee.FirstOrDefaultAsync(x => x.Id == Id);

            if (exitstEmployee == null)
            { 
                return NotFound();
            }
            exitstEmployee.Salutation = Employee.Salutation;
            exitstEmployee.FirstName = Employee.FirstName;
            exitstEmployee.LastName = Employee.LastName;
            exitstEmployee.Email = Employee.Email;
            exitstEmployee.Mobile_Number = Employee.Mobile_Number;
            exitstEmployee.Department = Employee.Department;
            exitstEmployee.Gender = Employee.Gender;
            exitstEmployee.Language = Employee.Language;
            exitstEmployee.Salary = Employee.Salary;
            exitstEmployee.Date_of_Birth = Employee.Date_of_Birth;
            exitstEmployee.Age = Employee.Age;

            await _context.SaveChangesAsync();
            return Ok(exitstEmployee);
        }

        [HttpPut("UpdateSupervisor/{id}")]
        public async Task<IActionResult> UpdateSupervisor(int Id, Supervisor Supervisor)
        {
            if (Id != Supervisor.Id)
            {
                return BadRequest();
            }
            var exitstSupervisor = await _context.Supervisor.FirstOrDefaultAsync(x => x.Id == Id);

            if (exitstSupervisor == null)
            {
                return NotFound();
            }
            exitstSupervisor.Supervisor_Salutation = Supervisor.Supervisor_Salutation;
            exitstSupervisor.Supervisor_FirstName = Supervisor.Supervisor_FirstName;
            exitstSupervisor.Supervisor_LastName = Supervisor.Supervisor_LastName;
            exitstSupervisor.Supervisor_Email = Supervisor.Supervisor_Email;
            exitstSupervisor.Supervisor_Mobile_Number = Supervisor.Supervisor_Mobile_Number;
            exitstSupervisor.Supervisor_Department = Supervisor.Supervisor_Department;
            exitstSupervisor.Supervisor_Gender = Supervisor.Supervisor_Gender;
            exitstSupervisor.Supervisor_Language = Supervisor.Supervisor_Language;
            exitstSupervisor.Supervisor_Salary = Supervisor.Supervisor_Salary;
            exitstSupervisor.Supervisor_Date_of_Birth = Supervisor.Supervisor_Date_of_Birth;
            exitstSupervisor.Supervisor_Age = Supervisor.Supervisor_Age;

            await _context.SaveChangesAsync();
            return Ok(exitstSupervisor);
        }


        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existEmployee = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (existEmployee == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(existEmployee);
            await _context.SaveChangesAsync();

            return Ok(existEmployee);
        }

        [HttpDelete("DeleteSupervisor/{id}")]
        public async Task<IActionResult> DeleteSupervisor(int id)
        {
            var existSupervisor = await _context.Supervisor.FirstOrDefaultAsync(x => x.Id == id);
            if (existSupervisor == null)
            {
                return NotFound();
            }
            _context.Supervisor.Remove(existSupervisor);
            await _context.SaveChangesAsync();

            return Ok(existSupervisor);
        }
        
    }
}