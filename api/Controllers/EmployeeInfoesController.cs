using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.Mappers;
using api.DTOs.Emp;

namespace api.Controllers
{
    [Route("api/EmployeeInfoes")]
    [ApiController]
    public class EmployeeInfoesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EmployeeInfoesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeInfoes
        [HttpGet]
        public IActionResult GetEmployees()
        {
            // Join operation
            var employees = _context.EmployeeInfos.Include(e => e.Department).Include(e => e.Designation).ToList().Select(s => s.ToEmployeeDetailedDTO());
            return Ok(employees);
        }
        // GET: api/EmployeeInfoes/5
        [HttpGet("{id}")]

        public IActionResult GetEmployee([FromRoute] int id)
        {
            var employee = _context.EmployeeInfos.Include(e => e.Department).Include(e => e.Designation)
                .FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee.ToEmployeeDetailedDTO());
        }

        // PUT: api/EmployeeInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeDTO employeeDTO)
        {
            var employeeModel = await _context.EmployeeInfos.Include(e => e.Department).Include(e => e.Designation).FirstOrDefaultAsync(e => e.Id == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            employeeModel.Name = employeeDTO.Name;
            employeeModel.DepartmentId = (int) employeeDTO.DepartmentId;
            employeeModel.DesignationId = (int) employeeDTO.DesignationId;

            await _context.SaveChangesAsync();
            
            //The following employeeModel line is not necessary. I added it for an optional reason. Previously when PUT
            //was executed, if DepartmentID or DesignationID were updated, the returned EmployeeDTO had the updated
            //fields as "Unknown". If both were updated, then both would show unknown. Name on the otherhand would not
            //show unknown, rather the updated value would show. In all cases, the database updates properly. However,
            //after doing a put request where I changed any of DepartmentID or DesignationID, if I resend the same request
            //without changing, then all fields show. Suppose in a specific put request to id 2, Name is Abir, DeptID I gave
            //2, DesignationID 3, then the response EmployeeDTO would have Abir as name, but DeptID and DesignationID would be
            //unknown. However, if I sent this same request again, all fields would show. This is because EF Core does not automatically
            //refresh the Navigation properties in the tracked entity (i.e. employeeModel). So after saving changes, I loaded
            //employeeModel again, so that the returned employeeDTO shows deptname and designame.
            employeeModel = await _context.EmployeeInfos.Include(e => e.Department).Include(e => e.Designation).FirstOrDefaultAsync(e => e.Id == id);
            return Ok(employeeModel.ToEmployeeDTO());
        }

        // PUT: api/EmployeeInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPatch("{id}")]
        public IActionResult UpdateEmployeePatch([FromRoute] int id, [FromBody] UpdateEmployeeDTO employeeDTO)
        {
            var employeeModel = _context.EmployeeInfos.FirstOrDefault(e => e.Id == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            if (employeeDTO.Name != null && employeeDTO.Name != "")
            {
                employeeModel.Name = employeeDTO.Name;
            }

            if (employeeDTO.DepartmentId.HasValue)
            {
                var dept = _context.Departments.Find(employeeDTO.DepartmentId.Value);
                if (dept != null)
                {
                    employeeModel.DepartmentId = dept.Id;
                }
            }
            if (employeeDTO.DesignationId.HasValue)
            {
                var desig = _context.Departments.Find(employeeDTO.DesignationId.Value);
                if (desig != null)
                {
                    employeeModel.DesignationId = desig.Id;
                }
            }

            _context.SaveChanges();

            return Ok(employeeModel.ToEmployeeDTO());
        }


        // POST: api/EmployeeInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostEmployeeInfo([FromBody] CreateEmployeeDTO employeeDTO)
        {
            var employeeInfo = employeeDTO.ToEmployeeInfoFromCreateDTO();
            _context.EmployeeInfos.Add(employeeInfo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEmployee), new { id = employeeInfo.Id }, employeeInfo.ToEmployeeDTO());
        }




        // DELETE: api/EmployeeInfoes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeInfo =  _context.EmployeeInfos.FirstOrDefault(e => e.Id == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            _context.EmployeeInfos.Remove(employeeInfo);
            _context.SaveChanges();

            return NoContent();
        }

        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfos.Any(e => e.Id == id);
        }
    }
}
