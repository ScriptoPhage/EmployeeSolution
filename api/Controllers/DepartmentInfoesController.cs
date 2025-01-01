using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentInfoesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DepartmentInfoesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentInfo>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/DepartmentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentInfo>> GetDepartmentInfo(int id)
        {
            var departmentInfo = await _context.Departments.FindAsync(id);

            if (departmentInfo == null)
            {
                return NotFound();
            }

            return departmentInfo;
        }

        // PUT: api/DepartmentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentInfo(int id, DepartmentInfo departmentInfo)
        {
            if (id != departmentInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DepartmentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentInfo>> PostDepartmentInfo(DepartmentInfo departmentInfo)
        {
            _context.Departments.Add(departmentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentInfo", new { id = departmentInfo.Id }, departmentInfo);
        }

        // DELETE: api/DepartmentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentInfo(int id)
        {
            var departmentInfo = await _context.Departments.FindAsync(id);
            if (departmentInfo == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(departmentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentInfoExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
