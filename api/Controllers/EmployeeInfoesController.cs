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
            return Ok(employee.ToEmployeeDTO());
        }

        // PUT: api/EmployeeInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeDTO employeeDTO)
        {
            var employeeModel = _context.EmployeeInfos.FirstOrDefault(e => e.Id == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            employeeModel.Name = employeeDTO.Name;
            employeeModel.DepartmentId = (int) employeeDTO.DepartmentId;
            employeeModel.DesignationId = (int) employeeDTO.DesignationId;

            _context.SaveChanges();

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

            if (employeeDTO.Name != null)
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
                    employeeModel.DepartmentId = desig.Id;
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
            _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfos.Any(e => e.Id == id);
        }
    }
}
