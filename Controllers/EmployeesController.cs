using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmloyeeContext _context;

        public EmployeesController(EmloyeeContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetEmploye()
        {
            return await _context.Employe.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmploye(long id)
        {
            var employe = await _context.Employe.FindAsync(id);

            if (employe == null)
            {
                return NotFound();
            }

            return employe;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(long id, Employe employe)
        {
            if (id != employe.Id)
            {
                return BadRequest();
            }

            _context.Entry(employe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employe>> PostEmploye(Employe employe)
        {
            _context.Employe.Add(employe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploye", new { id = employe.Id }, employe);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employe>> DeleteEmploye(long id)
        {
            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }

            _context.Employe.Remove(employe);
            await _context.SaveChangesAsync();

            return employe;
        }

        private bool EmployeExists(long id)
        {
            return _context.Employe.Any(e => e.Id == id);
        }
    }
}
