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
    public class DesignationInfoesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DesignationInfoesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/DesignationInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignationInfo>>> GetDesignations()
        {
            return await _context.Designations.ToListAsync();
        }

        // GET: api/DesignationInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignationInfo>> GetDesignationInfo(int id)
        {
            var designationInfo = await _context.Designations.FindAsync(id);

            if (designationInfo == null)
            {
                return NotFound();
            }

            return designationInfo;
        }

        // PUT: api/DesignationInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignationInfo(int id, DesignationInfo designationInfo)
        {
            if (id != designationInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(designationInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationInfoExists(id))
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

        // POST: api/DesignationInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DesignationInfo>> PostDesignationInfo(DesignationInfo designationInfo)
        {
            _context.Designations.Add(designationInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignationInfo", new { id = designationInfo.Id }, designationInfo);
        }

        // DELETE: api/DesignationInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignationInfo(int id)
        {
            var designationInfo = await _context.Designations.FindAsync(id);
            if (designationInfo == null)
            {
                return NotFound();
            }

            _context.Designations.Remove(designationInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesignationInfoExists(int id)
        {
            return _context.Designations.Any(e => e.Id == id);
        }
    }
}
